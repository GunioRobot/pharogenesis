classMenu: aMenu
	"Set up aMenu for the class-lis."

	parent ifNotNil:	[aMenu addList: #(  "These two only apply to dual change sorters"
		('copy class chgs to other side'			copyClassToOther)	
		('move class chgs to other side'			moveClassToOther))].

	aMenu addList: #(
		('delete class chgs from this change set'	forgetClass)
		-
		('browse full (b)'						browseMethodFull)
		('browse hierarchy (h)'					spawnHierarchy)
		('browse protocol'						spawnProtocol)
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
		('unsent methods'						browseUnusedMethods)
		('unreferenced inst vars'				showUnreferencedInstVars)
		('sample instance'						ÃmakeSampleInstance)).

	^ aMenu