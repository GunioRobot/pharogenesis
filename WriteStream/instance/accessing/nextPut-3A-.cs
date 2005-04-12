nextPut: anObject 
	"Primitive. Insert the argument at the next position in the Stream
	represented by the receiver. Fail if the collection of this stream is not an
	Array or a String. Fail if the stream is positioned at its end, or if the
	position is out of bounds in the collection. Fail if the argument is not
	of the right type for the collection. Optional. See Object documentation
	whatIsAPrimitive."

	<primitive: 66>
	((collection class == ByteString) and: [
		anObject isCharacter and:[anObject isOctetCharacter not]]) ifTrue: [
			collection _ (WideString from: collection).
			^self nextPut: anObject.
	].
	position >= writeLimit
		ifTrue: [^ self pastEndPut: anObject]
		ifFalse: 
			[position _ position + 1.
			^collection at: position put: anObject]