changeListMenu: aMenu

^ aMenu labels:
'fileIn selections
fileOut selections...
compare to current
toggle diffing
select conflicts with any changeset
select conflicts with current changeset
select conflicts with...
select unchanged methods
select methods for this class
select all
deselect all
browse current versions of selections
remove doIts
remove older versions
remove selections'
	lines: #(2 4 6 9 11 12)
	selections: #(fileInSelections fileOutSelections
compareToCurrentVersion toggleDiffing selectAllConflicts  selectConflicts selectConflictsWith selectUnchangedMethods selectMethodsForThisClass  selectAll  deselectAll browseCurrentVersionsOfSelections
removeDoIts removeOlderMethodVersions removeSelections)

"select such that...   selectSuchThat"

