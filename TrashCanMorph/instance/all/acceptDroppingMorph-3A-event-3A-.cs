acceptDroppingMorph: aMorph event: evt

	self world soundsEnabled  ifTrue: [self playDeleteSound].
	evt hand endDisplaySuppression.
	self color: self normalColor.
	aMorph delete.
