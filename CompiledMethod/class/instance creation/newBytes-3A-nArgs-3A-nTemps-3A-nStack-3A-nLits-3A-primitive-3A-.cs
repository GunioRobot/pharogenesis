newBytes: numberOfBytes nArgs: nArgs nTemps: nTemps nStack: stackSize nLits: nLits primitive: primitiveIndex
	"Answer an instance of me. The header is specified by the message 
	arguments. The remaining parts are not as yet determined."
	| largeBit primBits |
	largeBit _ (nTemps + stackSize) > SmallFrame ifTrue: [1] ifFalse: [0].
	primBits _ primitiveIndex <= 16r1FF
		ifTrue: [primitiveIndex]
		ifFalse: ["For now the high 2 bits of primitive no. are in high bits of header"
				(primitiveIndex bitAnd: 16r1FF) + ((primitiveIndex bitAnd: 16r600) bitShift: 19)].
	^ self newMethod: numberOfBytes + 4 	" +4 to store source code ptr" 
		header: (nArgs bitShift: 24) +
				(nTemps bitShift: 18) +
				(largeBit bitShift: 17) +
				(nLits bitShift: 9) +
				primBits