asMultiString 
	self isMultiString
		ifTrue:[^self]
		ifFalse:[^MultiString from: self]