rule6
	"Rule 6: Non-initial-consonant shortening."

	| nonInitial |
	nonInitial _ false.
	word events do: [ :each |
		(nonInitial and: [each phoneme isConsonant]) ifTrue: [each stretch: 0.85].
		nonInitial _ true]