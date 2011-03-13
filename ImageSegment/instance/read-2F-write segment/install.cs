install
	"This operation retrieves the segment if necessary from file storage, installs it in memory, and replaces (using become:) all the root stubs with the reconstructed roots of the segment."

	| newRoots |
	state = #onFile ifTrue: [self readFromFile].
	state = #onFileWithSymbols ifTrue: [self readFromFileWithSymbols.
		endMarker := segment nextObject. 	"for enumeration of objects"
		endMarker == 0 ifTrue: [endMarker := 'End' clone]].
	(state = #active) | (state = #imported) ifFalse: [self errorWrongState].
	newRoots := self loadSegmentFrom: segment outPointers: outPointers.
	state = #imported 
		ifTrue: ["just came in from exported file"
			arrayOfRoots := newRoots]
		ifFalse: [
			arrayOfRoots elementsForwardIdentityTo: newRoots].
	state := #inactive.
	Beeper beepPrimitive