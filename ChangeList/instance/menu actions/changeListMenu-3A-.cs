changeListMenu: aMenu
	"Fill aMenu up so that it comprises the primary changelist-browser menu"

	Smalltalk isMorphic ifTrue:
		[aMenu addTitle: 'change list'.
		aMenu addStayUpItemSpecial].

	aMenu addList: #(

	('fileIn selections'							fileInSelections)
	('fileOut selections...	'						fileOutSelections)
	-
	('compare to current'						compareToCurrentVersion)
	('toggle diffing (D)'							toggleDiffing)
	-
	('select conflicts with any changeset'		selectAllConflicts)
	('select conflicts with current changeset'	selectConflicts)
	-
	('select conflicts with...'						selectConflictsWith)
	('select unchanged methods'					selectUnchangedMethods)
	('select methods for this class'				selectMethodsForThisClass)
	('invert selections'							invertSelections)
	-
	('select all (a)'								selectAll)
	('deselect all'								deselectAll)
	-
	('browse current versions of selections'		browseCurrentVersionsOfSelections)
	('remove current methods of selections'		destroyCurrentCodeOfSelections)
	-
	('remove doIts'								removeDoIts)
	('remove older versions'						removeOlderMethodVersions)
	('remove selected items'						removeSelections)
	('remove unselected items'					removeNonSelections)).

	^ aMenu

