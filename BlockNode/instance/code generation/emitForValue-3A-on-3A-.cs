emitForValue: stack on: aStream
	| arg |
	aStream nextPut: LdThisContext.
	stack push: 1.
	nArgsNode emitForValue: stack on: aStream.
	remoteCopyNode
		emit: stack
		args: 1
		on: aStream.
	"Force a two byte jump."
	self emitLong: size code: JmpLong on: aStream.
	stack push: arguments size.
	arguments reverseDo: [:arg | arg emitStorePop: stack on: aStream].
	self emitForEvaluatedValue: stack on: aStream.
	self returns ifFalse: [aStream nextPut: EndRemote].
	stack pop: 1