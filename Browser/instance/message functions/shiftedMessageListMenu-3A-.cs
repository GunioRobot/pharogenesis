shiftedMessageListMenu: aMenu
	"Fill aMenu with the items appropriate when the shift key is held down"

	Smalltalk isMorphic ifTrue: [aMenu addStayUpItem].
	aMenu addList: #(
		('method pane' 							makeIsolatedCodePane)
		('tile scriptor'							openSyntaxView)
		('toggle diffing (D)'						toggleDiffing)
		('implementors of sent messages'			browseAllMessages)
		-
		('local senders of...'						browseLocalSendersOfMessages)
		('local implementors of...'				browseLocalImplementors)
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
		('change category...'					changeCategory)).

	self canShowMultipleMessageCategories ifTrue: [aMenu addList:
		 #(('show category (C)'						showHomeCategory))].
	aMenu addList: #(
		-
		('change sets with this method'			findMethodInChangeSets)
		('revert to previous version'				revertToPreviousVersion)
		('remove from current change set'		removeFromCurrentChanges)
		('revert & remove from changes'		revertAndForget)
		('add to current change set'				adoptMessageInCurrentChangeset)
		('copy up or copy down...'				copyUpOrCopyDown)
		-
		('more...' 								unshiftedYellowButtonActivity)).
	^ aMenu
