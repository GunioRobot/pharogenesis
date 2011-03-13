xBinary

	tokenType _ #binary.
	token _ self step asSymbol.
	[(typeTable at: hereChar asciiValue) = #xBinary and: [hereChar ~= $-]]
		whileTrue: [token _ (token , (String with: self step)) asSymbol]