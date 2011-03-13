insertPrefShortcut: short
					ServicePreferences
						addPreference: short
						categories: #('-- keyboard shortcuts --' )
						default: ''
						balloonHelp: 'enter a service id to bind it to this shortcut'
						projectLocal: false
						changeInformee: [self
								changeShortcut: short
								to: (ServicePreferences valueOfPreference: short)]
						changeSelector: #value
						viewRegistry: PreferenceViewRegistry ofTextPreferences