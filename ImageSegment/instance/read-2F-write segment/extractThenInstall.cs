extractThenInstall
	"For testing only"

	| newRoots |
	state = #activeCopy ifFalse: [self errorWrongState].
	arrayOfRoots elementsForwardIdentityTo:
		(arrayOfRoots collect: [:r | r rootStubInImageSegment: self]).
	state _ #active.
	newRoots _ self loadSegmentFrom: segment outPointers: outPointers.
	state _ #inactive.
	arrayOfRoots elementsForwardIdentityTo: newRoots.
