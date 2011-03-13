shiftedMessageListMenu: aMenu
	"Fill aMenu with the items appropriate when the shift key is held down"

	aMenu addList: #(
		('method pane' 							makeIsolatedCodePane)
		"('make a scriptor'						makeScriptor)"
		('toggle diffing (D)'						toggleDiffing)
		('implementors of sent messages'			browseAllMessages)
		-
		('spawn sub-protocol'					spawnProtocol)
		('spawn full protocol'					spawnFullProtocol)
		-
		('sample instance'						makeSampleInstance)
		('inspect instances'						inspectInstances)
		('inspect subinstances'					inspectSubInstances)).

	self addExtraShiftedItemsTo: aMenu.
	aMenu addList: #(
		-
		('change category...'					changeCategory)
		-
		('change sets with this method'			findMethodInChangeSets)
		('revert to previous version'				revertToPreviousVersion)
		('remove from current change set'		removeFromCurrentChanges)
		('revert & remove from changes'		revertAndForget)
		('add to current change set'				adoptMessageInCurrentChangeset)
		-
		('fetch documentation'					fetchDocPane)
		('more...' 								unshiftedYellowButtonActivity)).
	^ aMenu
