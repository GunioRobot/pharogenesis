offerMenu
	"Offer a menu to the user, in response to the hitting of the menu button on the tool pane"

	| aMenu |
	aMenu _ MenuMorph new defaultTarget: self.
	aMenu title: 'Messages of ', objectViewed nameForViewer.
	aMenu addStayUpItem.
	aMenu addList: #(
		('vocabulary...' 			chooseVocabulary)
		('what to show...'			offerWhatToShowMenu)
		-
		('inst var refs (here)'		setLocalInstVarRefs)
		('inst var defs (here)'		setLocalInstVarDefs)
		('class var refs (here)'		setLocalClassVarRefs)
		-

		('navigate to a sender...' 	navigateToASender)
		('recent...' 					navigateToRecentMethod)
		('show methods in current change set'
									showMethodsInCurrentChangeSet)
		('show methods with initials...'
									showMethodsWithInitials)
		-
		"('toggle search pane' 		toggleSearch)"

		-
		-
		('browse full (b)' 			browseMethodFull)
		('browse hierarchy (h)'		classHierarchy)
		('browse method (O)'		openSingleMessageBrowser)
		('browse protocol (p)'		browseFullProtocol)
		-
		('fileOut'					fileOutMessage)
		('printOut'					printOutMessage)
		-
		('senders of... (n)'			browseSendersOfMessages)
		('implementors of... (m)'		browseMessages)
		('versions (v)' 				browseVersions)
		('inheritance (i)'			methodHierarchy)
		-
		('inst var refs' 				browseInstVarRefs)
		('inst var defs' 				browseInstVarDefs)
		('class var refs' 			browseClassVarRefs)
		-
		('viewer on me'				viewViewee)
		('inspector on me'			inspectViewee)
		-
		('more...'					shiftedYellowButtonActivity)).

	aMenu popUpInWorld: ActiveWorld