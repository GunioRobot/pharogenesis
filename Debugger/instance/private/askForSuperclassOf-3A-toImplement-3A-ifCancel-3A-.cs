askForSuperclassOf: aClass toImplement: aSelector ifCancel: cancelBlock
	| classes chosenClassIndex |
	classes _ aClass withAllSuperclasses.
	chosenClassIndex _ PopUpMenu
		withCaption: 'Define #', aSelector, ' in which class?'
		chooseFrom: (classes collect: [:c | c name]).
	chosenClassIndex = 0 ifTrue: [^ cancelBlock value].
	^ classes at: chosenClassIndex