messageMenu: aMenu shifted: shifted
	"Fill aMenu with items appropriate for the message list; could be for a single or double changeSorter"

	shifted ifTrue: [^ self shiftedMessageMenu: aMenu].

	aMenu title: 'message list'.
	Smalltalk isMorphic ifTrue: [aMenu addStayUpItemSpecial].

	parent ifNotNil:
		[aMenu addList: #(
			('copy method to other side'			copyMethodToOther)
			('move method to other side'			moveMethodToOther))].

	aMenu addList: #(
			('delete method from change set'		forget)
			-
			('remove method from system (x)'	removeMessage)
				-
			('browse full (b)'					browseMethodFull)
			('browse hierarchy (h)'				spawnHierarchy)
			('browse method (O)'				openSingleMessageBrowser)
			('browse protocol (p)'				browseFullProtocol)
			-
			('fileOut'							fileOutMessage)
			('printOut'							printOutMessage)
			-
			('senders of... (n)'					browseSendersOfMessages)
			('implementors of... (m)'				browseMessages)
			('inheritance (i)'					methodHierarchy)
			('versions (v)'						browseVersions)
			-
			('more...'							shiftedYellowButtonActivity)).
	^ aMenu
