labelMorph
	"Answer the actual label morph."

	self hasSubmorphs ifFalse: [^nil].
	self firstSubmorph hasSubmorphs ifFalse: [^nil].
	^self firstSubmorph firstSubmorph