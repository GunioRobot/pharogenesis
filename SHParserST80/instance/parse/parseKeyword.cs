parseKeyword 
    | keyword rangeIndices type |
    self parseBinary.
	keyword := ''.
	rangeIndices := #().
	[
    		[self isKeyword]
        		whileTrue: [
				keyword := keyword, currentToken. 
				self rangeType: #keyword.
				"remember where this keyword token is in ranges"
				rangeIndices := rangeIndices copyWith: ranges size.
				self scanNext.
				self parseTerm.
				self parseBinary ]
	] ensure: [
		"do this in an ensure so that it happens even if the errorBlock evaluates before getting here"
		"patch up the keyword tokens, so that incomplete and undefined ones look different"
		(keyword isEmpty or:[Symbol hasInterned: keyword ifTrue: [:sym | ]])
			ifFalse:[
				type := (Symbol thatStartsCaseSensitive: keyword skipping: nil) isNil
					ifTrue: [#undefinedKeyword]
					ifFalse:[#incompleteKeyword].
				rangeIndices do: [:i | (ranges at: i) type: type]]]