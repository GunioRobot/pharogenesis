goToPageMorph: aMorph

	| i |
	i _ pages indexOf: aMorph.
	i = 0 ifFalse: [self goToPage: i].
