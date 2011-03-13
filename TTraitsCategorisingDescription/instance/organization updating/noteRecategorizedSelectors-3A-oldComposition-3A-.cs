noteRecategorizedSelectors: aCollection oldComposition: aTraitComposition
	| oldCategory newCategory |
	aCollection do: [:each | 
		oldCategory _ self organization categoryOfElement: each.
		newCategory _ (self traitComposition methodDescriptionForSelector: each) effectiveMethodCategory.
		self noteRecategorizedSelector: each from: oldCategory to: newCategory]