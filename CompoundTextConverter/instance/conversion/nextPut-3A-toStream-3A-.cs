nextPut: aCharacter toStream: aStream

	| ascii leadingChar class |
	aStream isBinary ifTrue: [^aCharacter storeBinaryOn: aStream].
	aCharacter isTraditionalDomestic ifFalse: [
		class := (EncodedCharSet charsetAt: aCharacter leadingChar) traditionalCharsetClass.
		ascii := (class charFromUnicode: aCharacter asUnicode) charCode.
		leadingChar := class leadingChar.
	] ifTrue: [
		ascii := aCharacter charCode.
		leadingChar := aCharacter leadingChar.
	].

	self nextPutValue: ascii toStream: aStream withShiftSequenceIfNeededForLeadingChar: leadingChar.
