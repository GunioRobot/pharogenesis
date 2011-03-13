testCommandIDMacOnly
	"menuItemCommandID value is set by VM"
	| menuHandle menuItemCommandID |

	self isMacintosh ifFalse: [^self].
	(SmalltalkImage current osVersion asNumber < 1000) 
		ifTrue: [^self].
	menuHandle := interface getMenuHandle: self applicationFirstMenu.
	menuItemCommandID := interface getMenuItemCommandID: menuHandle item: self quitItem.
	(SmalltalkImage current osVersion asNumber >= 1000 and: [SmalltalkImage current osVersion asNumber < 1030]) 
		ifTrue: [self should: [menuItemCommandID = 0]. ^self].
	(SmalltalkImage current osVersion asNumber >= 1030) 
		ifTrue: [self should: [menuItemCommandID = 1886545254]. ^self].
	self should: [menuItemCommandID = 0].

