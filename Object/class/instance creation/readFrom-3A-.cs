readFrom: aStream
	"Create an object based on the contents of aStream."

	| object ok |
	ok _ (aStream isKindOf: Stream) or: [aStream isKindOf: String].
	(ok or: [aStream isKindOf: Text]) ifFalse: [^ self error: 'expected String or Text'].
	object _ Compiler evaluate: aStream.
	(object isKindOf: self) ifFalse: [self error: self name, ' expected'].
	^object