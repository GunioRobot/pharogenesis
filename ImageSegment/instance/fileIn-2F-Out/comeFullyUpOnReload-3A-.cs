comeFullyUpOnReload: smartRefStream
	"fix up the objects in the segment that changed size.  An object in the segment is the wrong size for the modern version of the class.  Construct a fake class that is the old size.  Replace the modern class with the old one in outPointers.  Load the segment.  Traverse the instances, making new instances by copying fields, and running conversion messages.  Keep the new instances.  Bulk forward become the old to the new.  Let go of the fake objects and classes.
	After the install (below), arrayOfRoots is filled in.  Globalize new classes.  Caller may want to do some special install on certain objects in arrayOfRoots. 
	May want to write the segment out to disk in its new form."

	| mapFakeClassesToReal ccFixups receiverClasses |

	self flag: #bobconv.	

	RecentlyRenamedClasses _ nil.		"in case old data hanging around"
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
		self reshapeClasses: mapFakeClassesToReal refStream: smartRefStream
	].
	receiverClasses _ self restoreEndianness.		"rehash sets"
	smartRefStream checkFatalReshape: receiverClasses.

	"Classes in this segment."
	arrayOfRoots do: [:importedObject | 
		importedObject class class == Metaclass ifTrue: [self declare: importedObject]].
	arrayOfRoots do: [:importedObject | 
		(importedObject isKindOf: Project) ifTrue: [
			importedObject ensureChangeSetNameUnique.
			Project addingProject: importedObject.
			importedObject restoreReferences.
			ScriptEditorMorph writingUniversalTiles: 
				(importedObject world valueOfProperty: #universalTiles)]].
	
	arrayOfRoots do: [:importedObject | 
		(importedObject respondsTo: #unhibernate) ifTrue: [
			importedObject unhibernate].	"ScriptEditors and ViewerFlapTabs"
		].

	mapFakeClassesToReal isEmpty ifFalse: [
		mapFakeClassesToReal keys do: [:aFake | 
			aFake indexIfCompact > 0 ifTrue: [aFake becomeUncompact].
			aFake removeFromSystemUnlogged].
		SystemOrganization removeEmptyCategories].
	"^ self"