addBookMenuItemsTo: aCustomMenu hand: aHandMorph
	aCustomMenu
		add: (copyContents
				ifTrue: ['don''t be parts bin when closed']
				ifFalse: ['be parts bin when closed'])
		action: #toggleCopyContents.
	aCustomMenu add: 'previous page' action: #previousPage.
	aCustomMenu add: 'next page' action: #nextPage.
	aCustomMenu add: 'insert a page' action: #insertPage.
	aCustomMenu add: 'delete this page' action: #deletePage.
	aCustomMenu add: 'page controls' action: #pageControls:.
	aCustomMenu add: 'sort pages' action: #sortPages:.
