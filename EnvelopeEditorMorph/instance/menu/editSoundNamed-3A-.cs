editSoundNamed: name
	soundName _ name.
	self editSound: (AbstractSound soundNamed: soundName) copy