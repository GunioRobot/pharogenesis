simulatePrologInContext: aContext

	|cg instructions |
	cg _ SmartSyntaxPluginCodeGenerator new.
	parmSpecs keysAndValuesDo: 
		[:index :each |
		 instructions _ ((parmSpecs at: index)
			ccg: cg 
			prolog: (cg ccgTVarBlock: index) 
			expr: '<foo>' 
			index: args size - index).
		 Compiler new 
			evaluate: instructions
			in: aContext 
			to: aContext receiver
			notifying: nil
			ifFail: nil].
	instructions _ (rcvrSpec
		ccg: cg 
		prolog: [:expr | '^', expr]
		expr: '<foo>' 
		index: args size).
	 ^Compiler new 
		evaluate: instructions
		in: aContext 
		to: aContext receiver
		notifying: nil
		ifFail: nil