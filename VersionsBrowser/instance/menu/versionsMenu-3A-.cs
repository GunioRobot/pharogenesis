versionsMenu: aMenu
	"Fill aMenu with menu items appropriate to the receiver"

	^ aMenu addList: #(

		('compare to current'		compareToCurrentVersion)
		('revert to this version'		fileInSelections)
		('remove from changes'		removeMethodFromChanges)
		('toggle diffing (D)'			toggleDiffing)
		('update list'				reformulateList)
		('help...'					offerVersionsHelp))
