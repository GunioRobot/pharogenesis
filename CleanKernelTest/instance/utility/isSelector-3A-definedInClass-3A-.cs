isSelector: aSymbol definedInClass: aClassSymbol 
	| cls |
	cls := Smalltalk
				at: aClassSymbol
				ifAbsent: [^ false].
	^ cls selectors includes: aSymbol