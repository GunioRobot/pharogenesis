restoreFlapsDisplay
	(Preferences useGlobalFlaps and: [Project current flapsSuppressed not]) ifTrue:
		[Utilities globalFlapTabs do:
			[:aFlapTab | aFlapTab adaptToWorld]].
	self localFlapTabs do:
			[:aFlapTab | aFlapTab adaptToWorld].
	self assureFlapTabsFitOnScreen.
	self bringFlapTabsToFront