reshapedClassesIn: outPointers
	"Look for classes in the outPointer array that have changed shape.  Make a fake class for the old shape.  Return a dictionary mapping Fake classes to Real classes.  Substitute fake classes for real ones in outPointers."

	| mapFakeClassesToReal fakeCls |
	mapFakeClassesToReal _ IdentityDictionary new.
	outPointers withIndexDo: [:outp :ind | 
		(outp isKindOf: ClassDescription) ifTrue: [
			(fakeCls _ self mapClass: outp installIn: mapFakeClassesToReal) ifNotNil: [
				outPointers at: ind put: fakeCls]]].
	^ mapFakeClassesToReal