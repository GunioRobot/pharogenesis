basicLoad
	errorDefinitions := OrderedCollection new.
	[[additions do: [:ea | self tryToLoad: ea] displayingProgress: 'Loading...'.
	removals do: [:ea | ea unload] displayingProgress: 'Cleaning up...'.
	self shouldWarnAboutErrors ifTrue: [self warnAboutErrors].
	errorDefinitions do: [:ea | ea addMethodAdditionTo: methodAdditions] displayingProgress: 'Reloading...'.
	methodAdditions do: [:each | each installMethod].
	methodAdditions do: [:each | each notifyObservers].
	additions do: [:ea | ea postloadOver: (self obsoletionFor: ea)] displayingProgress: 'Initializing...']
		on: InMidstOfFileinNotification 
		do: [:n | n resume: true]]
			ensure: [self flushChangesFile]