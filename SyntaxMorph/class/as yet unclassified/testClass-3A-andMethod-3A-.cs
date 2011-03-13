testClass: aClass andMethod: aSelector

	| tree source |

	source _ (aClass compiledMethodAt: aSelector) getSourceFromFile.
	tree _ Compiler new 
		parse: source 
		in: aClass 
		notifying: nil.
	(tree asMorphicSyntaxUsing: SyntaxMorph)
		openInWindow.
