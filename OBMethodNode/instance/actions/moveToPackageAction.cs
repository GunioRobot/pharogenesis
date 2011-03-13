moveToPackageAction
	^ self 
		action: #moveToPackage
		withMenuLabel: 'move to package...'
		withButtonLabel: 'move method'
		withKeystroke: $p
		withIcon: (MenuIcons tryIcons: #(windowIcon smallWindowIcon)).
