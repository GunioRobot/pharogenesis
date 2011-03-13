copy 
	| newTrait |
	newTrait := self class basicNew initialize
		name: self name
		traitComposition: self traitComposition copyTraitExpression 
		methodDict: self methodDict copy
		localSelectors: self localSelectors copy
		organization: self organization copy.
		
	newTrait classTrait initializeFrom: self classTrait.
	^newTrait