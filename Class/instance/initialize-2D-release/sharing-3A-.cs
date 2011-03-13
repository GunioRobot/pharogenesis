sharing: poolString 
	"Set up sharedPools. Answer whether recompilation is advisable."
	| oldPools poolName pool found |
	oldPools _ self sharedPools.
	sharedPools _ OrderedCollection new.
	(Scanner new scanFieldNames: poolString) do: 
		[:poolName | 
		sharedPools add: (Smalltalk at: poolName asSymbol)].
	sharedPools isEmpty ifTrue: [sharedPools _ nil].
	oldPools do: [:pool | found _ false.
				self sharedPools do: [:p | p == pool ifTrue: [found _ true]].
				found ifFalse: [^ true "A pool got deleted"]].
	^ false