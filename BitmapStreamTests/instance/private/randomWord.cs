randomWord
	"Answer a random 32-bit integer"
	| w |
	random seed: (w _ random nextValue).
	^w truncated