readEvalPrint
	| line |
	[#('quit' 'exit' 'done' ) includes: (line _ self request: '>')]
		whileFalse: [self cr; show: ([Compiler evaluate: line]
			ifError: [:err :ex | err])]