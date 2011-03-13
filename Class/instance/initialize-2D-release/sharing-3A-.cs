sharing: poolString 
	"Set up sharedPools. Answer whether recompilation is advisable."
	| oldPools found |
	oldPools := self sharedPools.
	sharedPools := OrderedCollection new.
	(Scanner new scanFieldNames: poolString) do: 
		[:poolName | 
		sharedPools add: (self environment at: poolName asSymbol ifAbsent:[
			(self confirm: 'The pool dictionary ', poolName,' does not exist.',
						'\Do you want it automatically created?' withCRs)
				ifTrue:[self environment at: poolName asSymbol put: Dictionary new]
				ifFalse:[^self error: poolName,' does not exist']])].
	sharedPools isEmpty ifTrue: [sharedPools := nil].
	oldPools do: [:pool | found := false.
				self sharedPools do: [:p | p == pool ifTrue: [found := true]].
				found ifFalse: [^ true "A pool got deleted"]].
	^ false