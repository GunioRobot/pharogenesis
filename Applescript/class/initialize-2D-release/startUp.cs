startUp
	Smalltalk platformName = 'Mac OS' "Can be *really* annoying otherwise"
		ifTrue:[^self reopen]