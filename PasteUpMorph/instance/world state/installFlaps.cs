installFlaps
	self addGlobalFlaps.
	self localFlapTabs do:
			[:aFlapTab | aFlapTab adaptToWorld].
	self assureFlapTabsFitOnScreen.
	self bringFlapTabsToFront