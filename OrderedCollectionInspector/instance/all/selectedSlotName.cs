selectedSlotName
	"Answer the name of the currently selected slot, for the purpose of putting it into a menu title"

	^ (selectionIndex _ self selectionIndex) <= self baseFieldList size
		ifTrue:
			[super selectedSlotName]
		ifFalse:
			[ 'element ', self selectedObjectIndex printString, ' ']