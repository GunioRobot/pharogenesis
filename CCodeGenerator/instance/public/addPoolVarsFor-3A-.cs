addPoolVarsFor: aClass 
	"Add the pool variables for the given class to the code base as constants."
	aClass sharedPools do: [:pool |
		pool associationsDo: [:assoc |
			constants at: assoc key asString 
				put: (TConstantNode new setValue: assoc value)]]