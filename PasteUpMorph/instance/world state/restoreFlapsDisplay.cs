restoreFlapsDisplay
	(Preferences useGlobalFlaps and: [CurrentProjectRefactoring currentFlapsSuppressed not]) ifTrue:
		[Utilities globalFlapTabs do:
			[:aFlapTab | aFlapTab adaptToWorld]].
	self localFlapTabs do:
			[:aFlapTab | aFlapTab adaptToWorld].
	self assureFlapTabsFitOnScreen.
	self bringFlapTabsToFront