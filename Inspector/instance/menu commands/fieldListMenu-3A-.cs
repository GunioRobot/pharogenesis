fieldListMenu: aMenu
	"Arm the supplied menu with items for the field-list of the receiver"

	aMenu addStayUpItemSpecial.

	aMenu addList: #(
		('inspect (i)'						inspectSelection)
		('explore (I)'						exploreSelection)).

	self addCollectionItemsTo: aMenu.

	aMenu addList: #(
		-
		('method refs to this inst var'		referencesToSelection)
		('methods storing into this inst var'	defsOfSelection)
		('objects pointing to this value'		objectReferencesToSelection)
		('chase pointers'					chasePointers)
		('explore pointers'					explorePointers)
		-
		('browse full (b)'					browseMethodFull)
		('browse class'						browseClass)
		('browse hierarchy (h)'				classHierarchy)
		('browse protocol (p)'				browseFullProtocol)
		-
		('inst var refs...'					browseInstVarRefs)
		('inst var defs...'					browseInstVarDefs)
		('class var refs...'					classVarRefs)
		('class variables'					browseClassVariables)
		('class refs (N)'						browseClassRefs)
		-
		('copy name (c)'					copyName)		
		('basic inspect'						inspectBasic)
		).
	^ aMenu


