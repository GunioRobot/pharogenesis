menuFor: aServiceCategory 
	| submenu |
	submenu := self subMenuFor: aServiceCategory.
	^ submenu
		addTitle: (aServiceCategory menuLabel)