processFileContents
	"Process the contents of the flash file.
	Assume that the header has been read before."
	| time |
	time _ Time millisecondsToRun:[
	self isStreaming ifTrue:[
		"Don't show progress for a streaming connection.
		Note: Yielding is done someplace else."
		[self processTagFrom: stream] whileTrue.
	] ifFalse:[
		'Reading file' displayProgressAt: Sensor cursorPoint
			from: 1 to: 100
			during:[:theBar|

		[self processTagFrom: stream] whileTrue:[
			theBar value: (stream position * 100 // stream size).
			stream atEnd ifTrue:[
				log ifNotNil:[
					log cr; nextPutAll:'Unexpected end of data (no end tag)'.
					self flushLog].
				^self]].
		].
	].
	stream close.
	].
	Transcript cr; print: time / 1000.0; show:' secs to read file'