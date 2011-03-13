newBytes: numberOfBytes trailerBytes: trailer nArgs: nArgs nTemps: nTemps nStack: stackSize nLits: nLits primitive: primitiveIndex flag: flag
	"Answer an instance of me. The header is specified by the message 
	arguments. The remaining parts are not as yet determined."
	| largeBit primBits method flagBit |
	nTemps > 63 ifTrue:
		[^ self error: 'Cannot compile -- too many temporary variables'].	
	nLits > 255 ifTrue:
		[^ self error: 'Cannot compile -- too many literals variables'].	
	largeBit _ (nTemps + stackSize) > SmallFrame ifTrue: [1] ifFalse: [0].

	"For now the high bit of the primitive no. is in a high bit of the header"
	primBits _ (primitiveIndex bitAnd: 16r1FF) + ((primitiveIndex bitAnd: 16r200) bitShift: 19).

	flagBit := flag ifTrue: [ 1 ] ifFalse: [ 0 ].

	method _ self newMethod: numberOfBytes + trailer size
		header: (nArgs bitShift: 24) +
				(nTemps bitShift: 18) +
				(largeBit bitShift: 17) +
				(nLits bitShift: 9) +
				primBits +
				(flagBit bitShift: 29).

	"Copy the source code trailer to the end"
	1 to: trailer size do:
		[:i | method at: method size - trailer size + i put: (trailer at: i)].

	^ method