statementsFor: sourceText varName: varName
	"Return the parse tree for the given expression. The result is the statements list of the method parsed from the given source text."
	"Details: Various variables are declared as locals to avoid Undeclared warnings from the parser."

	| s |
	s _ WriteStream on: ''.
	s nextPutAll: 'temp'; cr; cr; tab.
	s nextPutAll: '| rcvr stackPointer successFlag ', varName,' |'; cr.
	s nextPutAll: sourceText.
	^ ((Compiler new parse: s contents in: Object notifying: nil)
			asTMethodFromClass: Object) statements
