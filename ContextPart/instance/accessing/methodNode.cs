methodNode

	| selector methodClass |
	selector _ self receiver class
		selectorAtMethod: self method
		setClass: [:mclass | methodClass _ mclass].
	^ self method methodNodeDecompileClass: methodClass selector: selector