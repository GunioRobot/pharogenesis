doPrimitive: primitiveName withArguments: argArray
	| proxy plugin |
	proxy _ InterpreterProxy new.
	proxy loadStackFrom: thisContext sender.
	plugin _ (self simulatorClass ifNil: [self]) new.
	plugin setInterpreter: proxy.
	^plugin perform: primitiveName asSymbol withArguments: argArray