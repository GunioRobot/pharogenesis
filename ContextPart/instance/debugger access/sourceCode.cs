sourceCode
	| selector methodClass |
	selector _ self receiver class selectorAtMethod: self method
		setClass: [:mclass | methodClass _ mclass].
	^self method getSourceFor: selector in: methodClass
	"Note: The above is a bit safer than
		^ methodClass sourceCodeAt: selector
	which may fail if the receiver's method has been changed in
	the debugger (e.g., the method is no longer in the methodDict
	and thus the above selector is something like #Doit:with:with:with:)
	but the source code is still available."