restoreFlapsDisplay
	"Restore the display of flaps"

	(Flaps sharedFlapsAllowed and: [CurrentProjectRefactoring currentFlapsSuppressed not]) ifTrue:
		[Flaps globalFlapTabs do:
			[:aFlapTab | aFlapTab adaptToWorld]].
	self localFlapTabs do:
			[:aFlapTab | aFlapTab adaptToWorld].
	self assureFlapTabsFitOnScreen.
	self bringTopmostsToFront