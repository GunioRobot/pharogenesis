updateWordingToMatchVocabulary

	| stringMorph |
	stringMorph _ submorphs
				detect: [:morph | morph class == StringMorph]
				ifNone: [^ self].
	stringMorph contents: 'random' translated.

