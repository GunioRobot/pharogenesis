initialize
	super initialize.
	showSplash _ true.
	HTTPClient isRunningInBrowser
		ifTrue: [whichFlaps _ 'etoy']