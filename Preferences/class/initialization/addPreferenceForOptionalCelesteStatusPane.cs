addPreferenceForOptionalCelesteStatusPane
	"Preferences addPreferenceForOptionalCelesteStatusPane"
	(FlagDictionary includesKey: #celesteHasStatusPane)
		ifFalse: [self
				addPreference: #celesteHasStatusPane
				category: #general
				default: false
				balloonHelp: 'If true, Celeste (e-mail reader) includes a status pane.'
			"Because Lex doesn't like it the default is false :)"]