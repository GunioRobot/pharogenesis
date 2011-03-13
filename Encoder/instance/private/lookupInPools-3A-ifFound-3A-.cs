lookupInPools: name ifFound: assocBlock

	| sym out |
	Symbol 
		hasInterned: name 
		ifTrue: [:sym | ^class scopeHas: sym ifTrue: assocBlock].
	^ class scopeHas: name ifTrue: assocBlock.  "Its a string in the pool"