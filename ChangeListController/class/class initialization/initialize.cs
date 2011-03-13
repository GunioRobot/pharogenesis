initialize
	"Class initialization: initialize the Yellow Button menu.
	 1/26/96 sw: added the remove items
	 9/18/96 sw: added selectUnchangedMethods and removeSelections"

	YellowButtonMenu _ PopUpMenu 
		labels:
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
		lines: #(2 6).
	YellowButtonMessages _ #(fileInSelections fileOutSelections selectConflicts selectConflictsWith selectUnchangedMethods selectAll deselectAll removeDoIts removeOlderMethodVersions removeSelections)
"
	ChangeListController initialize.
	ChangeListController allInstancesDo:
		[:x | x initializeYellowButtonMenu].
"