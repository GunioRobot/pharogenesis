testMenuHandlesGetMenu1CommandID
	| menuHandle menuItemCommandID |
	menuHandle := interface getMenuHandle: 1.
	menuItemCommandID := interface getMenuItemCommandID: menuHandle item: 8.
	(SmalltalkImage current  osVersion asNumber >= 1000) 
		ifTrue: [self should: [menuItemCommandID = 1886545254]]
		ifFalse: [self should: [menuItemCommandID = 0]]

