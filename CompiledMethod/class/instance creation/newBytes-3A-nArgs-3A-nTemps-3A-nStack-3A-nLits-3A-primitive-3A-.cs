newBytes: numberOfBytes nArgs: nArgs nTemps: nTemps nStack: stackSize nLits: nLits primitive: primitiveIndex
	"Answer an instance of me. The header is specified by the message 
	arguments. The remaining parts are not as yet determined."
	| largeBit |
	largeBit _ (nTemps + stackSize) > SmallFrame ifTrue: [1] ifFalse: [0].
	^ self 
		newMethod: numberOfBytes + 3 	"+3 to store source code ptr" 
		header: (nArgs bitShift: 24) +
				(nTemps bitShift: 18) +
				(largeBit bitShift: 17) +
				(nLits bitShift: 9) +
				primitiveIndex