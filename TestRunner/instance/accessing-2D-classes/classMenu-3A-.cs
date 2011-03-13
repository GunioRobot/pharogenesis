classMenu: aMenu
	| menu |
	menu := aMenu
		title: 'Classes';
		yourself.
	self browserEnvironment notNil ifTrue: [ 
		menu
			add: 'Browse classes' action: #browseTestClasses;
			add: 'Browse referenced classes' action: #browseReferencedClasses ].
	^ menu
		add: 'Browse sent messages' action: #browseSentMessages;
		addLine;
		add: 'Select all' action: #selectAllClasses;
		add: 'Select subclasses' action: #selectSubclasses;
		add: 'Select inversion' action: #selectInverseClasses;
		add: 'Select none' action: #selectNoClasses;
		addLine;
		add: 'Filter...' action: #filterClasses;
		addLine;
		add: 'Refresh' action: #updateClasses;
		yourself.