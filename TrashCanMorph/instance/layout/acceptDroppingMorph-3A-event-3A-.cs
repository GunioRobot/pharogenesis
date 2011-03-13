acceptDroppingMorph: aMorph event: evt 
	Preferences soundsEnabled
		ifTrue: [Preferences preserveTrash
				ifTrue: [self class playDeleteSound]
				ifFalse: [self playSoundNamed: 'scratch']].
	evt hand visible: true.
	self state: #off.
	aMorph delete.
	aMorph == Utilities scrapsBook
		ifFalse: [Utilities addToTrash: aMorph removeHalo]