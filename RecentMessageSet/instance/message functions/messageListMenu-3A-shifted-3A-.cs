messageListMenu: aMenu shifted: shifted
	"Answer the message-list menu"

	shifted ifTrue: [^ self shiftedMessageListMenu: aMenu].
	aMenu addList:#(
			('what to show...'						offerWhatToShowMenu)
			-
			('browse full (b)' 						browseMethodFull)
			('browse hierarchy (h)'					classHierarchy)
			('browse method (O)'					openSingleMessageBrowser)
			('browse protocol (p)'					browseFullProtocol)
			-
			('fileOut (o)'							fileOutMessage)
			('printOut'								printOutMessage)
			('copy selector (c)'						copySelector)
			-
			('senders of... (n)'						browseSendersOfMessages)
			('implementors of... (m)'					browseMessages)
			('inheritance (i)'						methodHierarchy)
			('versions (v)'							browseVersions)
			-
			('inst var refs...'						browseInstVarRefs)
			('inst var defs...'						browseInstVarDefs)
			('class var refs...'						browseClassVarRefs)
			('class variables'						browseClassVariables)
			('class refs (N)'							browseClassRefs)
			-
			('remove method (x)'					removeMessage)
			('remove from RecentSubmissions'		removeFromRecentSubmissions)
			-
			('more...'								shiftedYellowButtonActivity)).
	^ aMenu