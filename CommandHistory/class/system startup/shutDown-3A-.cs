shutDown: aboutToQuit 
	aboutToQuit ifFalse: [^ self].
	Preferences purgeUndoOnQuit ifTrue: [self resetAllHistory]