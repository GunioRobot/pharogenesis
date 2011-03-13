randomFloat
	"Answer a random 32-bit float"
	| w |
	random seed: (w := random nextValue).
	^w