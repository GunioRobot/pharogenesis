addPreferenceForOptionalCelesteStatusPane
	"Assure existence of a preference that governs the optional celeste status pane"

	Preferences preferenceAt: #celesteHasStatusPane ifAbsent:
		[Preferences
			addPreference: #celesteHasStatusPane
			category: #general
			default: false
			balloonHelp: 'If true, Celeste (e-mail reader) includes a status pane.'
		"Because Lex doesn't like it the default is false :)"]