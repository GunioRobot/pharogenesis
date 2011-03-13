testRestoreDefaultFonts

	self saveStandardSystemFontsDuring: [
		Preferences restoreDefaultFonts.
		self assert: #standardDefaultTextFont familyName: 'Accuny' pointSize: 10.
		self assert: #standardListFont familyName: 'Accuny' pointSize: 10.
		self assert: #standardFlapFont familyName: 'Accushi' pointSize: 12.
		self assert: #standardEToysFont familyName: 'BitstreamVeraSans' pointSize: 9.
		self assert: #standardMenuFont familyName: 'Accuny' pointSize: 10.
		self assert: #windowTitleFont familyName: 'BitstreamVeraSans' pointSize: 12.
		self assert: #standardBalloonHelpFont familyName: 'Accujen' pointSize: 9.
		self assert: #standardCodeFont familyName: 'Accuny' pointSize: 10.
		self assert: #standardButtonFont familyName: 'BitstreamVeraSansMono' pointSize: 9]