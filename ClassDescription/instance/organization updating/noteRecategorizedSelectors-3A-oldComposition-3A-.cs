noteRecategorizedSelectors: aCollection oldComposition: aTraitComposition
	| oldCategory newCategory |
	aCollection do: [:each | 
		oldCategory := self organization categoryOfElement: each.
		newCategory := (self traitComposition methodDescriptionForSelector: each) effectiveMethodCategory.
		self noteRecategorizedSelector: each from: oldCategory to: newCategory]