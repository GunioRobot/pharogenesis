comeFullyUpOnReload: smartRefStream
	"fix up the objects in the segment that changed size.  An object in the segment is the wrong size for the modern version of the class.  Construct a fake class that is the old size.  Replace the modern class with the old one in outPointers.  Load the segment.  Traverse the instances, making new instances by copying fields, and running conversion messages.  Keep the new instances.  Bulk forward become the old to the new.  Let go of the fake objects and classes.
	After the install (below), arrayOfRoots is filled in.  Globalize new classes.  Caller may want to do some special install on certain objects in arrayOfRoots.
	May want to write the segment out to disk in its new form."

	| mapFakeClassesToReal fakes goods bads perfect ccFixups real insts receiverClasses |
	mapFakeClassesToReal _ smartRefStream reshapedClassesIn: outPointers.
		"Dictionary of just the ones that change shape.  Substitute them in outPointers."
	ccFixups _ self remapCompactClasses: mapFakeClassesToReal 
				refStrm: smartRefStream.
	ccFixups ifFalse: [^ self error: 'A class in the file is not compatible'].
	endMarker _ segment nextObject. 	"for enumeration of objects"
	endMarker == 0 ifTrue: [endMarker _ 'End' clone].
	arrayOfRoots _ self loadSegmentFrom: segment outPointers: outPointers.
		"Can't use install.  Not ready for rehashSets"
	mapFakeClassesToReal isEmpty ifFalse: [
		fakes _ mapFakeClassesToReal keys.
		goods _ OrderedCollection new.
		bads _ OrderedCollection new.
		fakes do: [:aFakeClass | 
			real _ mapFakeClassesToReal at: aFakeClass.
			(real indexIfCompact > 0) "and there is a fake class"
				ifFalse: ["normal case"
					aFakeClass allInstancesDo: [:misShapen | 
						perfect _ smartRefStream convert: misShapen to: real.
						(bads includes: misShapen) ifFalse: [
							bads add: misShapen.
							goods add: perfect]]]
				ifTrue: ["instances have the wrong class.  Fix them before anyone notices."
					insts _ OrderedCollection new.
					self allObjectsDo: [:obj | obj class == real ifTrue: [insts add: obj]].
					insts do: [:misShapen | 
						perfect _ smartRefStream convert: misShapen to: real.
						(bads includes: misShapen) ifFalse: [
							bads add: misShapen.
							goods add: perfect]]]].

		bads size > 0 ifTrue: [
			bads asArray elementsForwardIdentityTo: goods asArray]].
	receiverClasses _ self restoreEndianness.		"rehash sets"
	smartRefStream checkFatalReshape: receiverClasses.

	"Classes in this segment."
	arrayOfRoots do: [:aRoot | 
		(aRoot isKindOf: Project) ifTrue: [
			Project allInstancesDo: [:pp | pp ~~ aRoot ifTrue: [
				pp name = aRoot name ifTrue: [
					aRoot projectChangeSet name: ChangeSet defaultName]]]].
		aRoot class class == Metaclass ifTrue: [
			self declare: aRoot]].

	mapFakeClassesToReal isEmpty ifFalse: [
		fakes do: [:aFake | 
			aFake indexIfCompact > 0 ifTrue: [aFake becomeUncompact].
			aFake removeFromSystemUnlogged].
		SystemOrganization removeEmptyCategories].
	"^ self"