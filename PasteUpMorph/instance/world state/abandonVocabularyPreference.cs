abandonVocabularyPreference
	"Remove any memory of a preferred vocabulary in the project"

	| standardViewers aVocabulary |
	self removeProperty: #currentVocabularySymbol.

	standardViewers _ (self submorphsSatisfying: [:m | m isKindOf: ViewerFlapTab]) collect:
		[:m | m referent firstSubmorph].
	aVocabulary _ Vocabulary vocabularyNamed: #eToy.
	standardViewers do:
		[:m | ((m valueOfProperty: #currentVocabularySymbol ifAbsent: [nil]) == #Vector) ifTrue:
			[m switchToVocabulary: aVocabulary]]

"ActiveWorld abandonVocabularyPreference"