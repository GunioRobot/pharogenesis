installVectorVocabulary
	"Install the experimental Vector vocabulary as the default for the current project"

	| standardViewers aVocabulary |
	self setProperty: #currentVocabularySymbol toValue: #Vector.
	standardViewers _ (self submorphsSatisfying: [:m | m isKindOf: ViewerFlapTab]) collect:
		[:m | m referent firstSubmorph].
	aVocabulary _ Vocabulary vocabularyNamed: #Vector.
	standardViewers do: [:m | m switchToVocabulary: aVocabulary]