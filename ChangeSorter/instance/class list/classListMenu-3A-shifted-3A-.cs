classListMenu: aMenu shifted: shifted
	"Fill aMenu with items appropriate for the class list"

	aMenu title: 'class list'.
	aMenu addStayUpItemSpecial.
	(parent notNil and: [shifted not])
		ifTrue: [aMenu addList: #( "These two only apply to dual change sorters"
			('copy class chgs to other side'			copyClassToOther)	
			('move class chgs to other side'			moveClassToOther))].

	aMenu addList: (shifted
		ifFalse: [#(
			-
			('delete class from change set (d)'		forgetClass)
			('remove class from system (x)'			removeClass)
			-
			('browse full (b)'						browseMethodFull)
			('browse hierarchy (h)'					spawnHierarchy)
			('browse protocol (p)'					browseFullProtocol)
			-
			('fileOut'								fileOutClass)
			-
			('inst var refs...'						browseInstVarRefs)
			('inst var defs...'						browseInstVarDefs)
			('class var refs...'						browseClassVarRefs)
			('class vars'								browseClassVariables)
			('class refs (N)'							browseClassRefs)
			-
			('more...'								offerShiftedClassListMenu))]

		ifTrue: [#(
			-
			('unsent methods'						browseUnusedMethods)
			('unreferenced inst vars'				showUnreferencedInstVars)
			('unreferenced class vars'				showUnreferencedClassVars)
			-
			('sample instance'						makeSampleInstance)
			('inspect instances'						inspectInstances)
			('inspect subinstances'					inspectSubInstances)
			-
			('more...'								offerUnshiftedClassListMenu ))]).
	^ aMenu