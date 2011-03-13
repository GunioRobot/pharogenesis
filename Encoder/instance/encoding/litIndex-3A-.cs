litIndex: literal
	| p |
	p _ literalStream position.
	p = 64 ifTrue:
		[self notify: 'More than 64 literals referenced. 
You must split or otherwise simplify this method.
The 65th literal is: ', literal printString. ^nil].
		"Would like to show where it is in the source code, 
		 but that info is hard to get."
	literalStream nextPut: literal.
	^ p