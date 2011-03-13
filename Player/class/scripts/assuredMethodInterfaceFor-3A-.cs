assuredMethodInterfaceFor: aSelector
	"Answer the method interface object for aSelector, creating it if it does not already exist."

	| selSym  aMethodInterface |
	selSym := aSelector asSymbol.
	aMethodInterface := self scripts at: selSym ifAbsent: 
		[scripts at: selSym put: (self nascentUserScriptInstance playerClass: self selector: selSym)].
	
	^ aMethodInterface