translateDoInlining: inlineFlag debug: debugFlag 
	^ self
		translate: self moduleName , '.c'
		doInlining: inlineFlag
		debug: debugFlag