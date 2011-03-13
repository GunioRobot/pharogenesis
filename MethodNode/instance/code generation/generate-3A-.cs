generate: trailer 
	"The receiver is the root of a parse tree. Answer a CompiledMethod. The
	argument, trailer, is the references to the source code that is stored with 
	every CompiledMethod."

	| literals blkSize method nArgs nLits primErrNode stack strm |
	self generate: trailer ifQuick: 
		[:m |
		literals := encoder allLiterals.
		(nLits := literals size) > 255 ifTrue:
			[^self error: 'Too many literals referenced'].
		1 to: nLits do: [:lit | m literalAt: lit put: (literals at: lit)].
		m properties: properties.
		^m].
	primErrNode := self primitiveErrorVariableName ifNotNil:
						[encoder fixTemp: self primitiveErrorVariableName].
	nArgs := arguments size.
	blkSize := (block sizeForEvaluatedValue: encoder)
				+ (primErrNode ifNil: [0] ifNotNil: [2 "We force store-long (129)"]).
	(nLits := (literals := encoder allLiterals) size) > 255 ifTrue:
		[^self error: 'Too many literals referenced'].
	method := CompiledMethod	"Dummy to allocate right size"
				newBytes: blkSize
				trailerBytes: trailer 
				nArgs: nArgs
				nTemps: encoder maxTemp
				nStack: 0
				nLits: nLits
				primitive: primitive.
	strm := ReadWriteStream with: method.
	strm position: method initialPC - 1.
	stack := ParseStack new init.
	primErrNode ifNotNil: [primErrNode emitStore: stack on: strm].
	block emitForEvaluatedValue: stack on: strm.
	stack position ~= 1 ifTrue:
		[^self error: 'Compiler stack discrepancy'].
	strm position ~= (method size - trailer size) ifTrue:
		[^self error: 'Compiler code size discrepancy'].
	method needsFrameSize: stack size.
	1 to: nLits do: [:lit | method literalAt: lit put: (literals at: lit)].
	method properties: properties.
	^method