sourceCode
	| selector methodClass |
	selector _ self receiver class selectorAtMethod: self method
		setClass: [:mclass | methodClass _ mclass].
	^ methodClass sourceCodeAt: selector