showFlap
	super showFlap.
	Preferences oneViewerFlapAtATime ifTrue:
		[self world hideViewerFlapsOtherThanFor: scriptedPlayer]