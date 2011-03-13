ofSoundThemePreferences
	"Answer the sound theme preference registry."
	
	^(self registryOf: #soundThemePreferences)
		viewOrder: 2;
		yourself