randomFloat
	"Answer a random 32-bit float"
	| w |
	random seed: (w _ random nextValue).
	^w