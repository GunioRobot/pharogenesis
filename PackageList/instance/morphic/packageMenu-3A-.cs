packageMenu: aMenu
	aMenu
		defaultTarget: self;
		add: 'add package' action: #addPackage.
	selectedPackage ifNotNil: [self packageContextMenu: aMenu].
	^ aMenu