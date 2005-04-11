isLiteralSymbol: aSymbol 
	"Test whether a symbol can be stored as # followed by its characters.  
	Symbols created internally with asSymbol may not have this property, 
	e.g. '3' asSymbol."
	| i ascii type |
	i _ aSymbol size.
	i = 0 ifTrue: [^ false].
	i = 1 ifTrue: [('$''"()#0123456789' includes: (aSymbol at: 1))
		ifTrue: [^ false] ifFalse: [^ true]].
	ascii _ (aSymbol at: 1) asciiValue.
	"TypeTable should have been origined at 0 rather than 1 ..."
	ascii = 0 ifTrue: [^ false].
	type _ TypeTable at: ascii ifAbsent:[#xLetter].
	(type == #xColon or: [type == #verticalBar or: [type == #xBinary]]) ifTrue: [
		i = 1 ifTrue: [^ true] ifFalse: [^ false]
	].
	type == #xLetter ifTrue: 
			[[i > 1]
				whileTrue: 
					[ascii _ (aSymbol at: i) asciiValue.
					ascii = 0 ifTrue: [^ false].
					type _ TypeTable at: ascii ifAbsent:[#xLetter].
					(type == #xLetter or: [type == #xDigit or: [type == #xColon]])
						ifFalse: [^ false].
					i _ i - 1].
			^ true].
	^ false