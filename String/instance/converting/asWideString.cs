asWideString 
	self isWideString
		ifTrue:[^self]
		ifFalse:[^WideString from: self]