messageListMenu: aMenu shifted: shifted
	"Answer the message-list menu"

	shifted ifTrue: [^ self shiftedMessageListMenu: aMenu].

	aMenu addList:#(
			('browse full (b)' 						browseMethodFull)
			('browse hierarchy (h)'					classHierarchy)
			('browse method (O)'					openSingleMessageBrowser)
			('browse protocol (p)'					browseFullProtocol)
			-
			('fileOut'								fileOutMessage)
			('printOut'								printOutMessage)
			-
			('senders of... (n)'						browseSendersOfMessages)
			('implementors of... (m)'					browseMessages)
			('inheritance (i)'						methodHierarchy)
			('tile scriptor'							openSyntaxView)
			('versions (v)'							browseVersions)
			-
			('inst var refs...'						browseInstVarRefs)
			('inst var defs...'						browseInstVarDefs)
			('class var refs...'						browseClassVarRefs)
			('class variables'						browseClassVariables)
			('class refs (N)'							browseClassRefs)
			-
			('remove method (x)'					removeMessage)
			-
			('more...'								shiftedYellowButtonActivity)).
	^ aMenu
