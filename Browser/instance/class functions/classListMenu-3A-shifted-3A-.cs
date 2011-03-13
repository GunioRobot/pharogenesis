classListMenu: aMenu shifted: shifted
	"Set up the menu to apply to the receiver's class list, honoring the #shifted boolean"

	^ aMenu addList: (shifted
		ifFalse: [#(
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
			-
			('more...'					shiftedYellowButtonActivity))]
		ifTrue: [#(
			-
			('unsent methods'			browseUnusedMethods)
			('unreferenced inst vars'	showUnreferencedInstVars)
			('subclass template'			makeNewSubclass)
			-
			('sample instance'			makeSampleInstance)
			('inspect instances'			inspectInstances)
			('inspect subinstances'		inspectSubInstances)
			-
			('fetch documentation'		fetchClassDocPane)
			('add all meths to current chgs'		addAllMethodsToCurrentChangeSet)
			-
			('more...'					unshiftedYellowButtonActivity))])