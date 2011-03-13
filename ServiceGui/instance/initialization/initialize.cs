initialize
	super initialize.
	menu := OrderedCollection new.
	bar := AlignmentMorph newRow.
	n := OrderedCollection with: 0