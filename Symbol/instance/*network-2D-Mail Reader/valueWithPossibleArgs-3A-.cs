valueWithPossibleArgs: args
	^ args first perform: self withArguments: (args allButFirst copyFrom: 1 to: self numArgs)