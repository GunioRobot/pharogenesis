changeListMenu: aMenu
	"Fill aMenu up so that it comprises the primary changelist-browser menu"

	Smalltalk isMorphic ifTrue:
		[aMenu addTitle: 'change list'.
		aMenu addStayUpItemSpecial].

	aMenu addList: #(

	('fileIn selections'							fileInSelections						'import the selected items into the image')
	('fileOut selections...	'						fileOutSelections						'create a new file containing the selected items')
	-
	('compare to current'						compareToCurrentVersion			'open a separate window which shows the text differences between the on-file version and the in-image version.' )
	('toggle diffing (D)'							toggleDiffing						'start or stop showing diffs in the code pane.')
	-
	('select conflicts with any changeset'		selectAllConflicts					'select methods in the file which also occur in any change-set in the system')
	('select conflicts with current changeset'	selectConflicts						'select methods in the file which also occur in the current change-set')
	('select conflicts with...'						selectConflictsWith					'allows you to designate a file or change-set against which to check for code conflicts.')
	-
	('select unchanged methods'					selectUnchangedMethods				'select methods in the file whose in-image versions are the same as their in-file counterparts' )
	('select new methods'						selectNewMethods					'select methods in the file that do not current occur in the image')
	('select methods for this class'				selectMethodsForThisClass			'select all methods in the file that belong to the currently-selected class')

	-
	('select all (a)'								selectAll								'select all the items in the list')
	('deselect all'								deselectAll							'deselect all the items in the list')
	('invert selections'							invertSelections						'select every item that is not currently selected, and deselect every item that *is* currently selected')
	-
	('browse all versions of single selection'			browseVersions		'open a version browser showing the versions of the currently selected method')
	('browse all versions of selections'			browseAllVersionsOfSelections		'open a version browser showing all the versions of all the selected methods')
	('browse current versions of selections'		browseCurrentVersionsOfSelections	'open a message-list browser showing the current (in-image) counterparts of the selected methods')
	('destroy current methods of selections'		destroyCurrentCodeOfSelections		'remove (*destroy*) the in-image counterparts of all selected methods')
	-
	('remove doIts'								removeDoIts							'remove all items that are doIts rather than methods')
	('remove older versions'						removeOlderMethodVersions			'remove all but the most recent versions of methods in the list')
	('remove up-to-date versions'				removeExistingMethodVersions		'remove all items whose code is the same as the counterpart in-image code')
	('remove selected items'						removeSelections					'remove the selected items from the change-list')
	('remove unselected items'					removeNonSelections					'remove all the items not currently selected from the change-list')).

	^ aMenu

