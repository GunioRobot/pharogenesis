classMenu: aMenu shifted: shifted
	"Fill aMenu with items appropriate for the class list"

	aMenu title: 'class list'.
	Smalltalk isMorphic ifTrue: [aMenu addStayUpItemSpecial].
	(parent notNil and: [shifted not])
		ifTrue: [aMenu addList: #( "These two only apply to dual change sorters"
			('copy class chgs to other side'			copyClassToOther)	
			('move class chgs to other side'			moveClassToOther))].

	^ aMenu addList: (shifted
		ifFalse: [#(
			-
			('delete class chgs from this change set'	forgetClass)
			-
			('browse full (b)'						browseMethodFull)
			('browse hierarchy (h)'					spawnHierarchy)
			('browse protocol (p)'					browseFullProtocol)
			-
			('printOut'								printOutClass)
			('fileOut'								fileOutClass)
			-
			('inst var refs...'						browseInstVarRefs)
			('inst var defs...'						browseInstVarDefs)
			('class var refs...'						browseClassVarRefs)
			('class vars'								browseClassVariables)
			('class refs (N)'							browseClassRefs)
			-
			('more...'								shiftedYellowButtonActivity))]
		ifTrue: [#(
			-
			('unsent methods'						browseUnusedMethods)
			('unreferenced inst vars'				showUnreferencedInstVars)
			-
			('sample instance'						makeSampleInstance)
			('inspect instances'						inspectInstances)
			('inspect subinstances'					inspectSubInstances)
			-
			('more...'								unshiftedYellowButtonActivity))])