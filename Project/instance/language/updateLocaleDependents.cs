updateLocaleDependents
	"Set the project's natural language as indicated"

	ActiveWorld allTileScriptingElements do: [:viewerOrScriptor |
			viewerOrScriptor localeChanged].

	Flaps disableGlobalFlaps: false.
	Preferences eToyFriendly
		ifTrue: [
			Flaps addAndEnableEToyFlaps.
			ActiveWorld addGlobalFlaps]
		ifFalse: [Flaps enableGlobalFlaps].

	(Project current isFlapIDEnabled: 'Navigator' translated)
		ifFalse: [Flaps enableDisableGlobalFlapWithID: 'Navigator' translated].

	Utilities emptyScrapsBook.
	MenuIcons initializeTranslations.

	LanguageEnvironment localeChanged.

	"self setFlaps.
	self setPaletteFor: aLanguageSymbol."
