generate: trailer
	"The receiver is the root of a parse tree. Answer a CompiledMethod. The 
	argument, trailer, is the references to the source code that is stored with 
	every CompiledMethod."
	| blkSize method nLits lit stack strm nArgs i |
	self generateIfQuick: 
		[:method | 
		1 to: 3 do: [:i | method at: method size - 3 + i put: (trailer at: i)].
		method cacheTempNames: self tempNames.
		^method].
	nArgs _ arguments size.
	blkSize _ block sizeForEvaluatedValue: encoder.
	encoder maxTemp > 31
		ifTrue: [^self error: 'Too many temporary variables'].	
	literals _ encoder allLiterals.
	(nLits _ literals size) > 63
		ifTrue: [^self error: 'Too many literals referenced'].
	method _ CompiledMethod	"Dummy to allocate right size"
				newBytes: blkSize
				nArgs: nArgs
				nTemps: encoder maxTemp
				nStack: 0
				nLits: nLits
				primitive: primitive.
	strm _ ReadWriteStream with: method.
	strm position: method initialPC - 1.
	stack _ ParseStack new init.
	block emitForEvaluatedValue: stack on: strm.
	stack position ~= 1 ifTrue: [^self error: 'Compiler stack discrepancy'].
	strm position ~= (method size - 3) 
		ifTrue: [^self error: 'Compiler code size discrepancy'].
	method needsFrameSize: stack size.
	1 to: nLits do: [:lit | method literalAt: lit put: (literals at: lit)].
	1 to: 3 do: [:i | method at: method size - 3 + i put: (trailer at: i)].
	method cacheTempNames: self tempNames.
	^method