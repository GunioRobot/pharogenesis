newBytes: numberOfBytes trailerBytes: trailer nArgs: nArgs nTemps: nTemps nStack: stackSize nLits: nLits primitive: primitiveIndex
	"Answer an instance of me. The header is specified by the message 
	arguments. The remaining parts are not as yet determined."
	| largeBit primBits method |
	nTemps > 63 ifTrue:
		[^ self error: 'Cannot compile -- too many temporary variables'].	
	nLits > 255 ifTrue:
		[^ self error: 'Cannot compile -- too many literals variables'].	
	largeBit := (nTemps + stackSize) > SmallFrame ifTrue: [1] ifFalse: [0].
	primBits := primitiveIndex <= 16r1FF
		ifTrue: [primitiveIndex]
		ifFalse: ["For now the high bit of primitive no. is in the 29th bit of header"
				primitiveIndex > 16r3FF ifTrue: [self error: 'prim num too large'].
				(primitiveIndex bitAnd: 16r1FF) + ((primitiveIndex bitAnd: 16r200) bitShift: 19)].
	method := self newMethod: numberOfBytes + trailer size
		header: (nArgs bitShift: 24) +
				(nTemps bitShift: 18) +
				(largeBit bitShift: 17) +
				(nLits bitShift: 9) +
				primBits.
	1 to: trailer size do:  "Copy the source code trailer to the end"
		[:i | method at: method size - trailer size + i put: (trailer at: i)].
	^ method