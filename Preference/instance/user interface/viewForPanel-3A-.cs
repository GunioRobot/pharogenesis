viewForPanel: aPreferencePanel
	| viewClass |
	viewClass _ self viewClassForPanel: aPreferencePanel.
	^viewClass ifNotNil: [viewClass preference: self]