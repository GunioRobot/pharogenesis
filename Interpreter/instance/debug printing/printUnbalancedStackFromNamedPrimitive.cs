printUnbalancedStackFromNamedPrimitive
	| lit |
	self inline: false.
	self print: 'Stack unbalanced after '.
	successFlag 
		ifTrue:[self print:'successful '] 
		ifFalse:[self print: 'failed '].
	lit _ self literal: 0 ofMethod: newMethod.
	self printStringOf: (self fetchPointer: 1 ofObject: lit).
	self print:' in '.
	self printStringOf: (self fetchPointer: 0 ofObject: lit).
	self cr.
		