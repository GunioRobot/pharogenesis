streamContents: blockWithArg 
	| stream |
	stream _ TextStream on: (self new: 400).
	blockWithArg value: stream.
	^ stream contents