streamContents: blockWithArg
	| stream |
	stream _ WriteStream on: (self new: 100).
	blockWithArg value: stream.
	^stream contents