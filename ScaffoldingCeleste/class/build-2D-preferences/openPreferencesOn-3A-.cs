openPreferencesOn: aModel 
	| topWindow  |
	Smalltalk isMorphic
		ifFalse: [self error: 'Preferences not available in MVC yet :('].
	topWindow := (SystemWindow labelled: 'Celeste Preferences')
				model: aModel.

	self buildPreferenceView:topWindow.
	topWindow openInWorld.