selectItem: aMenuItem event: anEvent
	selectedItem ifNotNil:[selectedItem deselect: anEvent].
	selectedItem _ aMenuItem.
	selectedItem ifNotNil:[selectedItem select: anEvent].