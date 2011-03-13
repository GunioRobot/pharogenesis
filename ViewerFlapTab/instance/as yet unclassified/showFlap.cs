showFlap
	super showFlap.
	Preferences oneViewerFlapAtATime ifTrue:
		[self pasteUpMorph hideViewerFlapsOtherThanFor: scriptedPlayer]