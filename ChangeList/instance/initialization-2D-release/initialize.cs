initialize
	showDiffs _ Preferences diffsInChangeList.
	changeList _ OrderedCollection new.
	list _ OrderedCollection new.
	listIndex _ 0.
	super initialize