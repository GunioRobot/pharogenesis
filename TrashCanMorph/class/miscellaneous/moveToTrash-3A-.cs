moveToTrash: aMorph
	Preferences soundsEnabled ifTrue:
		[Preferences preserveTrash 
			ifFalse:
				[self playSoundNamed: 'scratch']
			ifTrue:
				[self playDeleteSound]].

	aMorph delete.
	aMorph == Utilities scrapsBook ifFalse:
		[Utilities addToTrash: aMorph]