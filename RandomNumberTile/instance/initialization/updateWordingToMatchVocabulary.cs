updateWordingToMatchVocabulary

	| stringMorph |
	stringMorph := submorphs
				detect: [:morph | morph class == StringMorph]
				ifNone: [^ self].
	stringMorph contents: 'random' translated.

