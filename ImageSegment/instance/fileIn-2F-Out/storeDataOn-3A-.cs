storeDataOn: aDataStream
	"Don't wrote the array of Roots.  Also remember the structures of the classes of objects inside the segment."

	| tempRoots tempOutP list |
	state = #activeCopy ifFalse: [self error: 'wrong state'].
		"real state is activeCopy, but we changed it will be right when coming in"
	tempRoots _ arrayOfRoots.
	tempOutP _ outPointers.
	outPointers _ outPointers clone.
	self prepareToBeSaved.
	arrayOfRoots _ nil.
	state _ #imported.
	super storeDataOn: aDataStream.		"record my inst vars"
	arrayOfRoots _ tempRoots.
	outPointers _ tempOutP.
	state _ #activeCopy.
	aDataStream references at: #AnImageSegment put: false.	"the false is meaningless"
		"This key in refs is the flag that there is an ImageSegment in this file."

	"Find the receivers of blocks in the segment.  Need to get the structure of their classes into structures.  Put the receivers into references."
	(aDataStream byteStream isKindOf: DummyStream) ifTrue: [
		list _ Set new.
		arrayOfRoots do: [:ea | 
			(ea class == BlockContext) | (ea class == MethodContext) ifTrue: [ 
				list add: ea receiver class ]].
		aDataStream references at: #BlockReceiverClasses put: list].
