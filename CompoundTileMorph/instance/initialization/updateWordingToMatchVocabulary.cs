updateWordingToMatchVocabulary
	| labels |
	labels := OrderedCollection new.
	self submorphs do: [:submorph |
		submorph submorphs do: [:subsubmorph |
			subsubmorph class == StringMorph ifTrue: [labels add: subsubmorph]]].
	labels do: [:label | label knownName ifNotNilDo: [ :nm | label acceptValue: nm translated ]]
