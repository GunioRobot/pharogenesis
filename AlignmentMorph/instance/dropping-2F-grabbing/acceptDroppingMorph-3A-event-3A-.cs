acceptDroppingMorph: aMorph event: evt
	"Allow the user to add submorphs just by dropping them on this morph."
	self privateAddMorph: aMorph atIndex: (self insertionIndexFor: aMorph).
	self changed.
	self layoutChanged.
