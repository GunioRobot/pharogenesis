parseStream: aStream
	"Read the 3DS file from the given stream"
	| sceneSpec |
	source := aStream.
	source binary.
	indent := 0.
	log := Sensor leftShiftDown ifTrue: [
		Sensor controlKeyPressed
			ifTrue: [FileStream fileNamed: (FillInTheBlank request: 'Parser log file:' initialAnswer: 'parser.log')]
			ifFalse: [Transcript]].
	log == Transcript ifTrue: [log clear].
	sceneSpec := self scene.
	log == nil ifFalse: [log == Transcript ifTrue: [log flush] ifFalse: [log close]].
	^self sceneClass from3DS: sceneSpec