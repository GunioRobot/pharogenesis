changeListMenu: aMenu

^ aMenu labels:
'fileIn selections
fileOut selections...
select conflicts
select conflicts with
select unchanged methods
select all
deselect all
remove doIts
remove older versions
remove selections'
	lines: #(2 6)
	selections: #(fileInSelections fileOutSelections selectConflicts selectConflictsWith selectUnchangedMethods selectAll deselectAll removeDoIts removeOlderMethodVersions removeSelections)
