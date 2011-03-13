initialize
	bars _ OrderedCollection new.
	(TheWorldMenu respondsTo: #registerOpenCommand:)
		ifTrue: [TheWorldMenu unregisterOpenCommand: 'Services Browser'.
			TheWorldMenu registerOpenCommand: {'Services Browser'. {PreferenceBrowser. #openForServices}}]