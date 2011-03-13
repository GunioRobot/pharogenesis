messageListMenu: aMenu shifted: shifted 
	"Answer the message-list menu"
	ServiceGui browser: self messageListMenu: aMenu.
	ServiceGui onlyServices ifTrue: [^ aMenu].
	shifted
		ifTrue: [^ self shiftedMessageListMenu: aMenu].
	aMenu addList: #(
			('what to show...'			offerWhatToShowMenu)
			('toggle break on entry'		toggleBreakOnEntry)
			-
			('browse full (b)' 			browseMethodFull)
			('browse hierarchy (h)'			classHierarchy)
			('browse method (O)'			openSingleMessageBrowser)
			('browse protocol (p)'			browseFullProtocol)
			-
			('fileOut'				fileOutMessage)
			-
			('senders of... (n)'			browseSendersOfMessages)
			('implementors of... (m)'		browseMessages)
			('inheritance (i)'			methodHierarchy)
			('versions (v)'				browseVersions)
			-
			('inst var refs...'			browseInstVarRefs)
			('inst var defs...'			browseInstVarDefs)
			('class var refs...'			browseClassVarRefs)
			('class variables'			browseClassVariables)
			('class refs (N)'			browseClassRefs)
			-
			('remove method (x)'			removeMessage)
			-
			('more...'				shiftedYellowButtonActivity)).
	^ aMenu