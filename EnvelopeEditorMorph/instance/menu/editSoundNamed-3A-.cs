editSoundNamed: name

	name = 'new...' ifTrue: [^ self editNewSound].
	soundName _ name.
	self editSound: (AbstractSound soundNamed: soundName) copy