versionsMenu: aMenu
	"Fill aMenu with menu items appropriate to the receiver"

	Smalltalk isMorphic ifTrue:
		[aMenu title: 'Versions' translated.
		aMenu addStayUpItemSpecial].

	listIndex > 0 ifTrue:[
		(list size > 1 ) ifTrue: [ aMenu addTranslatedList: #(
			('compare to current'		compareToCurrentVersion		'compare selected version to the current version')
			('compare to version...'	compareToOtherVersion		'compare selected version to another selected version'))].
		"Note: Revert to selected should be visible for lists of length one for having the ability to revert to an accidentally deleted method"
		 aMenu addTranslatedList: #(
			('revert to selected version'	fileInSelections					'resubmit the selected version, so that it becomes the current version') )].

	aMenu addTranslatedList: #(
		('remove from changes'		removeMethodFromChanges	'remove this method from the current change set, if present')
		('edit current method (O)'	openSingleMessageBrowser		'open a single-message browser on the current version of this method')		
		('find original change set'	findOriginalChangeSet			'locate the changeset which originally contained this version')
		-
		('toggle diffing (D)'			toggleDiffing					'toggle whether or not diffs should be shown here')
		('update list'				reformulateList					'reformulate the list of versions, in case it somehow got out of synch with reality')
		-
		('senders (n)'				browseSenders					'browse all senders of this selector')
		('implementors (m)'			browseImplementors			'browse all implementors of this selector')
		-
		('help...'					offerVersionsHelp				'provide an explanation of the use of this tool')).
											
	^aMenu