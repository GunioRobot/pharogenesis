addAddHandMenuItemsForHalo: aMenu
	"Add halo menu items to be handled by the invoking hand."

	self colorSettable
		ifTrue: [aMenu add: 'fill color' action: #changeColor].
