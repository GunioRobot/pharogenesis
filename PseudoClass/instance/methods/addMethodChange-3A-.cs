addMethodChange: aChangeRecord
	| selector |
	selector := self parserClass new parseSelector: aChangeRecord string.
	self organization classify: selector under: aChangeRecord category.
	self sourceCodeAt: selector put: aChangeRecord