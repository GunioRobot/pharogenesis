methodListMenu: aMenu
	selection ifNotNil:
		[aMenu addList:#(
			('install'	 installSelection)
			('revert'	 revertSelection)
			-)].
	super methodListMenu: aMenu.
	^ aMenu
