browseAction
	^ self 
		action: #browse
		withMenuLabel: 'browse'
		withButtonLabel: 'browse'
		withKeystroke: $b
		withIcon: (MenuIcons tryIcons: #(windowIcon smallWindowIcon)).
