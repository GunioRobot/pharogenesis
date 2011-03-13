newPreferenceListPanel
	"Answer a groupbox for the preferences list."
	
	^(UITheme builder
		newGroupbox: 'Preferences' translated
		for: self preferenceList)
		cornerStyle: StandardWindow basicNew preferredCornerStyle