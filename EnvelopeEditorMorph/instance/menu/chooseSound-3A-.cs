chooseSound: evt
	| menu |
	menu _ MenuMorph new.
	menu add: 'new' target: self selector: #editNewSound.
	menu addLine.
	AbstractSound soundNames do:
		[:name |
		menu add: name
			target: self selector: #editSoundNamed:
			argument: name].
	menu popUpAt: evt hand position event: evt.
