chosenCategorySymbol: aCategorySymbol
	"Make the given category be my current one."

	| aCategory wording |
	chosenCategorySymbol _ aCategorySymbol.
	aCategory _ self currentVocabulary categoryAt: chosenCategorySymbol.
	wording _ aCategory ifNil: [aCategorySymbol] ifNotNil: [aCategory wording].
	self categoryWording: wording