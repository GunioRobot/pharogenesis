nextPut: aCharacter toStream: aStream

	| ascii leadingChar class |
	aStream isBinary ifTrue: [^aCharacter storeBinaryOn: aStream].
	aCharacter isUnicode ifTrue: [
		class _ (EncodedCharSet charsetAt: aCharacter leadingChar) traditionalCharsetClass.
		ascii _ (class charFromUnicode: aCharacter asUnicode) charCode.
		leadingChar _ class leadingChar.
	] ifFalse: [
		ascii _ aCharacter charCode.
		leadingChar _ aCharacter leadingChar.
	].

	self nextPutValue: ascii toStream: aStream withShiftSequenceIfNeededForLeadingChar: leadingChar.
