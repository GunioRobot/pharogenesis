categoryForParent: aCategory
	"Answer the one of my categories with parent <aCategory>, if I have it."

	categories ifNil: [^nil].
	^categories detect: [:cat | cat parent = aCategory ] ifNone: [nil]