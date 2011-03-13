getResponseShowing: showFlag

	| line idx |
	line _ WriteStream on: String new.

	buffer ifNil: [
		buffer _ String new.
		bufferPos _ 0 ].

	[
		"look for a LF in the buffer"
		idx _ buffer indexOf: Character lf startingAt: bufferPos+1 ifAbsent: [ 0 ].
		idx > 0 ifTrue: [
			"found it! we have a line"
			line nextPutAll: (buffer copyFrom: bufferPos+1 to: idx-1).
			bufferPos _ idx.
			^line contents ].
		
		"didn't find it.  add the whole buffer to the line, and retrieve some more data"
		line nextPutAll: (buffer copyFrom: bufferPos+1 to: buffer size).
		bufferPos _ 0.
		buffer _ String new.
		self waitForDataQueryingUserEvery: 30.
		buffer _ self getData.

		true
	] whileTrue.