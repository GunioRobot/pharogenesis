testClass: aClass andMethod: aSelector
	| tree |
	tree _ Compiler new 
		parse: (aClass sourceCodeAt: aSelector) 
		in: aClass 
		notifying: nil.
	(tree asMorphicSyntaxUsing: SyntaxMorph)
		parsedInClass: aClass;
		openInWindow