rule9b
	"Rule 9b: Postvocalic context of vowels."

	| events current next nextnext |
	phrase lastSyllable == syllable ifFalse: [^ self].
	events _ syllable events.
	1 to: events size do: [ :i |
		current _ events at: i.
		next _ i + 1 <= events size ifTrue: [(events at: i + 1) phoneme].
		nextnext _ i + 2 <= events size ifTrue: [(events at: i + 2) phoneme].
		current stretch: 0.3 * (self rule9a: current phoneme next: next nextnext: nextnext) + 0.7]