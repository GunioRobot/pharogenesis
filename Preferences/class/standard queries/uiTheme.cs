uiTheme
	^ self
		valueOfFlag: #uiTheme
		ifAbsent: [UIThemeStandardSqueak]