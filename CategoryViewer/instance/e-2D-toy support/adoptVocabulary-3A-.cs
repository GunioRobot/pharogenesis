adoptVocabulary: aVocabulary
	"Adopt the given vocabulary as the one used in this viewer."

	| aCategory |
	chosenCategorySymbol ifNil: [^ self delete].
	aCategory _ aVocabulary categoryAt: chosenCategorySymbol.
	aCategory ifNil: [self delete] ifNotNil: [self updateCategoryNameTo: aCategory wording].
	super adoptVocabulary: aVocabulary