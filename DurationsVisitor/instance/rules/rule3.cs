rule3
	"Rule 3: Non-phrase-final shortening.
	Syllabic segments are shortened by 60 if not in a phrase-final syllable."

	phrase syllablesDo: [ :each |
		phrase lastSyllable == each
			ifFalse: [each events do: [ :event | event phoneme isSyllabic ifTrue: [event stretch: 0.6]]]]