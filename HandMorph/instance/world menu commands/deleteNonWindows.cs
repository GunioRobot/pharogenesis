deleteNonWindows
	(SelectionMenu confirm:
'Do you really want to discard all objects
that are not in windows?')
		ifFalse: [^ self].

	self world allNonFlapRelatedSubmorphs do:
		[:m | m delete]