rule4
	"Rule 4: Non-word-final shortening.
	Syllabic segments are shortened by 85 if not in a word-final syllable."

	word lastSyllable == syllable ifTrue: [^ self].
	syllable events do: [ :each | each phoneme isSyllabic ifTrue: [each stretch: 0.85]]