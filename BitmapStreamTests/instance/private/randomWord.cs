randomWord
	"Answer a random 32-bit integer"
	| w |
	random seed: (w := random nextValue).
	^w truncated