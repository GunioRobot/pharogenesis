isLiteralMultiSymbol: aMultiSymbol
	"Test whether a symbol can be stored as # followed by its characters.  
	Symbols created internally with asSymbol may not have this property, 
	e.g. '3' asSymbol."
	| i ascii type |
	i _ aMultiSymbol size.
	i = 0 ifTrue: [^ false].
	i = 1 ifTrue: [('$''"()#0123456789' includes: (aMultiSymbol at: 1))
		ifTrue: [^ false] ifFalse: [^ true]].
	ascii _ (aMultiSymbol at: 1) asciiValue.
	"TypeTable should have been origined at 0 rather than 1 ..."
	(ascii = 0
			or: [ascii > 255])
		ifTrue: [^ false].
	type _ TypeTable at: ascii.
	(type == #xColon or: [type == #verticalBar]) ifTrue: [^ i = 1].
	type == #xBinary ifTrue: 
			[[i > 1]
				whileTrue: 
					[ascii _ (aMultiSymbol at: i) asciiValue.
					ascii = 0 ifTrue: [^ false].
					(TypeTable at: ascii) == #xBinary ifFalse: [^ false].
					i _ i - 1].
			^ true].
	type == #xLetter ifTrue: 
			[[i > 1]
				whileTrue: 
					[ascii _ (aMultiSymbol at: i) asciiValue.
					ascii = 0 ifTrue: [^ false].
					type _ TypeTable at: ascii ifAbsent: [#xLetter].
					(type == #xLetter or: [type == #xDigit or: [type == #xColon]])
						ifFalse: [^ false].
					i _ i - 1].
			^ true].
	^ false