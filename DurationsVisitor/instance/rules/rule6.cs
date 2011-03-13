rule6
	"Rule 6: Non-initial-consonant shortening."

	| nonInitial |
	nonInitial := false.
	word events do: [ :each |
		(nonInitial and: [each phoneme isConsonant]) ifTrue: [each stretch: 0.85].
		nonInitial := true]