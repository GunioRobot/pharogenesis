actions
	^{ 
		self action: #fileOut withLabel: 'file out'.
		self browseAction.
		self browseHierarchyAction.
		self 
			action: #browseSenders
			withMenuLabel: 'senders'
			withButtonLabel: 'senders'
			withKeystroke: $n
			withIcon: (MenuIcons tryIcons: #(findIcon smallFindIcon)).
		self 
			action: #browseImplementors
			withMenuLabel: 'implementors'
			withButtonLabel: 'implementors'
			withKeystroke: $m
			withIcon: (MenuIcons tryIcons: #(findIcon smallFindIcon)).
		self 
			action: #browseVersions
			buttonLabel: 'versions'
			menuLabel: 'versions'.
		self 
			action: #browseInheritance
			buttonLabel: 'inheritance'
			menuLabel: 'inheritance'.
		self 
			action: #chaseVars
			buttonLabel: 'variables'
			menuLabel: 'chase variables'.
		self 
			action: #remove
			withLabel: 'remove'
			withKeystroke: $x
			withIcon: (MenuIcons tryIcons: #(deleteIcon smallDeleteIcon)).
		self moveToPackageAction
	}
