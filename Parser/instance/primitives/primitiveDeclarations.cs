primitiveDeclarations
	| prim module |
	(self matchToken: 'primitive:') ifFalse:[^self externalFunctionDeclaration].
	prim _ here.
	(self match: #number) ifTrue:[^prim].	"Indexed primitives"
	(self match: #string) ifFalse:[^self expected:'Integer or String'].
	(self matchToken: 'module:') ifTrue:[
		module _ here.
		(self match: #string) ifFalse:[^self expected: 'String'].
		module _ module asSymbol].
	(self allocateLiteral: (Array with: module with: prim asSymbol with: 0 with: 0)).
	^117