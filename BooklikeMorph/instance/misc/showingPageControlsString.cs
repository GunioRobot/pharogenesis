showingPageControlsString
	^ (self pageControlsVisible
		ifTrue: ['hide page controls']
		ifFalse: ['show page controls']) translated