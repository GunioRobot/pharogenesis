yellowButtonMenu

	^ Preferences noviceMode
			ifTrue: [self yellowButtonNoviceMenu]
			ifFalse: [self yellowButtonExpertMenu]
