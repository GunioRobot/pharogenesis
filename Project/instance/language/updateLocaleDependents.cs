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

	ParagraphEditor initializeTextEditorMenus.
	Utilities emptyScrapsBook.
	MenuIcons initializeTranslations.

	LanguageEnvironment localeChanged.

	#(PartsBin ParagraphEditor BitEditor FormEditor StandardSystemController) 
		do: [ :key | Smalltalk at: key ifPresent: [ :class | class initialize ]].
	"self setFlaps.
	self setPaletteFor: aLanguageSymbol."
