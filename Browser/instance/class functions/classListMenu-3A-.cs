classListMenu: aMenu 
	^ aMenu addList: #(

		-
		('browse full (b)'			browseMethodFull)
		('browse hierarchy (h)'		spawnHierarchy)
		('browse protocol'			spawnProtocol)
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
		('unsent methods'			browseUnusedMethods)
		('unreferenced inst vars'	showUnreferencedInstVars)
		('subclass template'			makeNewSubclass)
		('sample instance'			ÃmakeSampleInstance)
		-
		('find method...'				findMethod)
		('fetch documentation'		fetchClassDocPane))