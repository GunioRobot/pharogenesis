representativeButtonWithColor: aColor inPanel: aPanel
	| view |
	view _ self viewForPanel: aPanel.
	^view ifNotNil: [view representativeButtonWithColor: aColor inPanel: aPanel]