secreteCategorySymbol
	"Set my chosenCategorySymbol by translating back from its representation in the namePane.  Answer the chosenCategorySymbol"

	| aCategory |
	aCategory _ self currentVocabulary categoryWhoseTranslatedWordingIs: self currentCategory.
	^ chosenCategorySymbol _ aCategory
		ifNotNil:
			[aCategory categoryName]
		ifNil:
			[self currentCategory]