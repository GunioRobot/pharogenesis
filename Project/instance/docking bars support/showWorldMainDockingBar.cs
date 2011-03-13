showWorldMainDockingBar

	^ self projectPreferenceFlagDictionary
		at: #showWorldMainDockingBar
		ifAbsent: [Preferences showWorldMainDockingBar]