xBinary

	tokenType _ #binary.
	token _ self step asSymbol.
	[| type | 
	type _ typeTable at: hereChar asciiValue ifAbsent: [#xLetter].
	type == #xBinary and: [hereChar ~= $-]] whileTrue: [
		token _ (token, (String with: self step)) asSymbol].
