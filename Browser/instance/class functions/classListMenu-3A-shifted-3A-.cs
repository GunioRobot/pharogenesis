classListMenu: aMenu shifted: shifted
	"Set up the menu to apply to the receiver's class list, honoring the #shifted boolean"

	ServiceGui browser: self classMenu: aMenu.
	ServiceGui onlyServices  ifTrue: [^aMenu].
	shifted
		ifTrue:
			[^ self shiftedClassListMenu: aMenu].
	aMenu addList: #(
		-
		('browse full (b)'			browseMethodFull)
		('browse hierarchy (h)'		spawnHierarchy)
		('browse protocol (p)'		browseFullProtocol)
		-
		('printOut'					printOutClass)
		('fileOut'					fileOutClass)
		-
		('show hierarchy'			hierarchy)
		('show definition'			editClass)
		('show comment'			editComment)
		-
		('inst var refs...'			browseInstVarRefs)
		('inst var defs...'			browseInstVarDefs)
		-
		('class var refs...'			browseClassVarRefs)
		('class vars'					browseClassVariables)
		('class refs (N)'				browseClassRefs)
		-
		('rename class ...'			renameClass)
		('copy class'				copyClass)
		('remove class (x)'			removeClass)
		-
		('find method...'				findMethod)
		('find method wildcard...'	findMethodWithWildcard)
		-
		('more...'					offerShiftedClassListMenu)).
	^ aMenu
