canHaveFillStyles
	"Return true if the receiver can have general fill styles; not just colors.
	This method is for gradually converting old morphs."
	^self class == RectangleMorph "no subclasses"