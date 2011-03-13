selectTabNamed: aString
	self world abandonAllHalos.
	self highlightTabName: aString.
	owner goToPageMorphNamed: aString