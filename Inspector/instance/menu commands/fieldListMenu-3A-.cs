fieldListMenu: aMenu
	"Arm the supplied menu with items for the field-list of the receiver"

	| sel |
	((((sel _ self selection) isMemberOf: Array) or: [sel isMemberOf: OrderedCollection]) and: [sel size >= 1])
		ifTrue:
			[^ self fieldListMenuForCollection: aMenu].

	aMenu addList: #(

		('inspect (i)'						inspectSelection)
		('explore (I)'						exploreSelection)
		-
		('method refs to this inst var'		referencesToSelection)
		('methods storing into this inst var'	defsOfSelection)
		('objects pointing to this value'		objectReferencesToSelection)
		-
		('browse full (b)'					browseMethodFull)
		('browse class'						browseClass)
		('browse hierarchy'					classHierarchy)
		-
		('inst var refs...'					browseInstVarRefs)
		('inst var defs...'					browseInstVarDefs)
		('class var refs...'					classVarRefs)
		('class variables'					browseClassVariables)
		('class refs (N)'						browseClassRefs)
		-
		('copy name'						copyName)		
		('basic inspect'						inspectBasic)).

	Smalltalk isMorphic ifTrue:
		[aMenu addList: #(
			-
			('tile for this value	(t)'			tearOffTile)
"			('alias for this value'			aliasForValue)"
"			('watcher for this slot'			watcherForSlot)"
			('viewer for this value (v)'		viewerForValue))].

	^ aMenu

