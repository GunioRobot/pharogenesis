unregisterFromOpenMenu
	 (TheWorldMenu respondsTo: #registerOpenCommand:)
		ifTrue: [TheWorldMenu unregisterOpenCommand: 'Preference Browser'].
