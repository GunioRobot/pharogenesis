fullScreen
	| possibleBounds |
	possibleBounds _ self world bounds.
	(Preferences useGlobalFlaps and: [Project current flapsSuppressed not]) ifTrue:
		[possibleBounds _ possibleBounds insetBy: 22].
	self bounds: possibleBounds