noteNewOwner: aMorph
	| window |
	window := aMorph containingWindow.
	window ifNotNil: [self adoptPaneColor: window paneColor]