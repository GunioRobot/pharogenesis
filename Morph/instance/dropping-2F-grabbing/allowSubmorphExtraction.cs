allowSubmorphExtraction
	"Return true if this morph allows its submorphs to be extracted just by grabbing them. This default implementation returns false."

	^self dragNDropEnabled
		or: [self dragEnabled]