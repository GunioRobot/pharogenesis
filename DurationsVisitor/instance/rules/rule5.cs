rule5
	"Rule 5: Polysyllabic Shortening.
	Syllabic segments in a polysyllabic word are shortened by 80."

	word isPolysyllabic ifFalse: [^ self].
	syllable events do: [ :each | each phoneme isSyllabic ifTrue: [each stretch: 0.8]]