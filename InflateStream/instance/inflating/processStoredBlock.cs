processStoredBlock
	| chkSum length |
	"Skip to byte boundary"
	self nextBits: (bitPos bitAnd: 7).
	length _ self nextBits: 16.
	chkSum _ self nextBits: 16.
	(chkSum bitXor: 16rFFFF) = length
		ifFalse:[^self error:'Bad block length'].
	litTable _ nil.
	distTable _ length.
	state _ state bitOr: BlockProceedBit.
	^self proceedStoredBlock