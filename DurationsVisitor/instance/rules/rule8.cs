rule8
	"Rule 8: Lengthening for emphasis."

	word isAccented
		ifTrue: [word events do: [ :each | each phoneme isVowel ifTrue: [each stretch: 1.4]]]