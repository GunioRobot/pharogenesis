categoryNameWhoseTranslatedWordingIs: aWording
	"Answer the category name with the given wording"

	| result |
	result _ self currentVocabulary categoryWhoseTranslatedWordingIs: aWording.
	^ result
		ifNotNil:
			[result categoryName]
		ifNil:
			[aWording]