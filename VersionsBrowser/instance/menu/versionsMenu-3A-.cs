versionsMenu: aMenu
	^ aMenu labels:

'compare to current
revert to this version
remove from changes
toggle diffing
update list
help...'
	lines: #()
	selections: #(compareToCurrentVersion fileInSelections removeMethodFromChanges toggleDiffing reformulateList offerVersionsHelp)
