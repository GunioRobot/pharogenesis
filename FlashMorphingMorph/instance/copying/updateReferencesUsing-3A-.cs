updateReferencesUsing: aDictionary 
	| srcMorph dstMorph |
	super updateReferencesUsing: aDictionary.
	srcMorph := submorphs at: submorphs size - 1.
	dstMorph := submorphs last.
	self removeAllMorphs.
	self from: srcMorph to: dstMorph