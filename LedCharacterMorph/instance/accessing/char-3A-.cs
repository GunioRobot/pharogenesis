char: aCharacter 
	char _ aCharacter digitValue.
	char >= 0 & (char <= 35) ifFalse: [char _ 36]