generateToByDo: msgNode on: aStream indent: level
	"Generate the C code for this message onto the given stream."

	| iterationVar step |
	(msgNode args last args size = 1) ifFalse: [
		self error: 'wrong number of block arguments'.
	].
	iterationVar _ msgNode args last args first.
	aStream nextPutAll: 'for (', iterationVar, ' = '.
	self emitCExpression: msgNode receiver on: aStream.
	aStream nextPutAll: '; ', iterationVar,
		(((step _ msgNode args at: 2) isConstant and: [step value < 0])
			ifTrue: [' >= '] ifFalse: [' <= ']).
	self emitCExpression: msgNode args first on: aStream.
	aStream nextPutAll: '; ', iterationVar, ' += '.
	self emitCExpression: step on: aStream.
	aStream nextPutAll: ') {'; cr.
	msgNode args last emitCCodeOn: aStream level: level + 1 generator: self.
	level timesRepeat: [ aStream tab ].
	aStream nextPutAll: '}'.