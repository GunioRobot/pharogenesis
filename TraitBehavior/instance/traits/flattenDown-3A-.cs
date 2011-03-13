flattenDown: aTrait
	| selectors |
	self assert: [self hasTraitComposition and: [self traitComposition allTraits includes: aTrait]].
	selectors := (self traitComposition transformationOfTrait: aTrait) selectors.
	self basicLocalSelectors: self basicLocalSelectors , selectors.
	self removeFromComposition: aTrait.