generateNative: trailer 
	"The receiver is the root of a parse tree. Answer a CompiledMethod. The
	argument, trailer, is the references to the source code that is stored with 
	every CompiledMethod."

	| blkSize nLits stack strm nArgs method |
	self generate: trailer ifQuick: 
		[:m |  method _ m.
		method cacheTempNames: self tempNames.
		^ method].
	nArgs _ arguments size.
	blkSize _ block sizeForEvaluatedValue: encoder.
	literals _ encoder allLiterals.
	(nLits _ literals size) > 255
		ifTrue: [^self error: 'Too many literals referenced'].
	method _ CompiledMethod	"Dummy to allocate right size"
				newBytes: blkSize
				trailerBytes: trailer 
				nArgs: nArgs
				nTemps: encoder maxTemp
				nStack: 0
				nLits: nLits
				primitive: primitive.
	strm _ ReadWriteStream with: method.
	strm position: method initialPC - 1.
	stack _ ParseStack new init.
	block emitForEvaluatedValue: stack on: strm.
	stack position ~= 1 ifTrue: [^self error: 'Compiler stack
discrepancy'].
	strm position ~= (method size - trailer size) 
		ifTrue: [^self error: 'Compiler code size discrepancy'].
	method needsFrameSize: stack size.
	1 to: nLits do: [:lit | method literalAt: lit put: (literals at: lit)].
	method cacheTempNames: self tempNames.
	^ method