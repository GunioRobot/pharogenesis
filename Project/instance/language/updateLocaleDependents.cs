updateLocaleDependents
	"Set the project's natural language as indicated"

"Probably, the whole method can be removed in the process of the EToys removal. For now comment this part out since rebuilding flaps does not work anymore."

"	ActiveWorld allTileScriptingElements do: [:viewerOrScriptor |
			viewerOrScriptor localeChanged].

	Flaps disableGlobalFlaps: false.
	Flaps enableGlobalFlaps.

	(Project current isFlapIDEnabled: 'Navigator' translated)
		ifFalse: [Flaps enableDisableGlobalFlapWithID: 'Navigator' translated].
"
	MenuIcons initializeTranslations.

	LanguageEnvironment localeChanged.
