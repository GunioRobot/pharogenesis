onColor
"Private - answer the on color"
	^ (Preferences menuSelectionColor
		ifNil: [Color blue])
		alpha: 0.4