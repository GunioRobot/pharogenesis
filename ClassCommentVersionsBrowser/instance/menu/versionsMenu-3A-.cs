versionsMenu: aMenu
	"Fill aMenu with menu items appropriate to the receiver"

	aMenu title: 'versions'.
	aMenu addStayUpItemSpecial.
	^ aMenu addList: #(

		('compare to current'		compareToCurrentVersion		'compare selected version to the current version')
		('revert to selected version'	fileInSelections					'resubmit the selected version, so that it becomes the current version')
		('remove from changes'		removeMethodFromChanges		'remove this method from the current change set, if present')
		('edit current method (O)'	openSingleMessageBrowser		'open a single-message browser on the current version of this method')		
		-
		('toggle diffing (D)'			toggleDiffing					'toggle whether or not diffs should be shown here')
		('update list'				reformulateList					'reformulate the list of versions, in case it somehow got out of synch with reality')
		-
		('help...'					offerVersionsHelp				'provide an explanation of the use of this tool'))
