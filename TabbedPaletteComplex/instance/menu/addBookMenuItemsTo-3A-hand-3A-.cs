addBookMenuItemsTo: aCustomMenu hand: aHandMorph
	aCustomMenu add: 'add tab' action: #insertTab.
	aCustomMenu add: 'delete selected tab' action: #deleteTab.
