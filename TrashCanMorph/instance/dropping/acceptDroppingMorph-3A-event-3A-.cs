acceptDroppingMorph: aMorph event: evt

	Preferences soundsEnabled ifTrue:
		[Preferences preserveTrash 
			ifFalse:
				[self playSoundNamed: 'scratch']
			ifTrue:
				[self class playDeleteSound]].

	evt hand endDisplaySuppression.
	self state: #off.
	aMorph delete.
	aMorph == Utilities scrapsBook ifFalse:
		[Utilities addToTrash: aMorph]