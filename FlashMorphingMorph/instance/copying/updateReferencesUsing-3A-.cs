updateReferencesUsing: aDictionary
	| srcMorph dstMorph |
	super updateReferencesUsing: aDictionary.
	srcMorph _ (submorphs at: submorphs size-1).
	dstMorph _ (submorphs at: submorphs size).
	self removeAllMorphs.
	self from: srcMorph to: dstMorph.
