ofUIThemePreferences
	"Answer the ui theme preference registry."
	
	^(self registryOf: #uiThemePreferences)
		viewOrder: 2;
		yourself