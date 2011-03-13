recompile: aWorkingCopy
	aWorkingCopy packageInfo methods
		do: [ :each | each actualClass recompile: each methodSymbol ]