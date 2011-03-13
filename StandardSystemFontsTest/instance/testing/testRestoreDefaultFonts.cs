testRestoreDefaultFonts
	self saveStandardSystemFontsDuring: [
		Preferences restoreDefaultFonts.
		self assert: #standardDefaultTextFont familyName: 'Accuny' pointSize: 9.
		self assert: #standardListFont familyName: 'Accuny' pointSize: 9.
		self assert: #standardMenuFont familyName: 'Accuny' pointSize: 9.
		self assert: #windowTitleFont familyName: 'Accuny' pointSize: 12.
		self assert: #standardBalloonHelpFont familyName: 'Accuny' pointSize: 10.
		self assert: #standardCodeFont familyName: 'Accuny' pointSize: 9.
		self assert: #standardButtonFont familyName: 'Accuny' pointSize: 9]