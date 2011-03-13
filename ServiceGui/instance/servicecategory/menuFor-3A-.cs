menuFor: aServiceCategory 
	| submenu |
	submenu _ self subMenuFor: aServiceCategory.
	^ submenu
		addTitle: (aServiceCategory menuLabel)