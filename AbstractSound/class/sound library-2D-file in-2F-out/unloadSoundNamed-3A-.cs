unloadSoundNamed: soundName

	(Sounds includesKey: soundName) ifTrue: [
		Sounds at: soundName put: self unloadedSound].
	self updateScorePlayers.
