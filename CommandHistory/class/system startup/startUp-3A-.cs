startUp: resuming 
	resuming ifFalse: [^ self].
	Preferences purgeUndoOnQuit ifFalse: [self resetAllHistory]
 
	