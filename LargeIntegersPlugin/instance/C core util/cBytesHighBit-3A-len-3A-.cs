cBytesHighBit: pByte len: len 
	"Answer the index (in bits) of the high order bit of the receiver, or zero if the    
	 receiver is zero. This method is allowed (and needed) for     
	LargeNegativeIntegers as well, since Squeak's LargeIntegers are     
	sign/magnitude."
	| realLength lastDigit |
	self var: #pByte declareC: 'unsigned char *  pByte'.
	realLength _ len.
	[(lastDigit _ pByte at: realLength - 1) = 0]
		whileTrue: [(realLength _ realLength - 1) = 0 ifTrue: [^ 0]].
	^  (self cHighBit: lastDigit) + (8 * (realLength - 1))