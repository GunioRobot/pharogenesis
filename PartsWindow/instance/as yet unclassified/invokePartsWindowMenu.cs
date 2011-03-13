invokePartsWindowMenu
	"Put up a menu offering parts-bin controls"

	| aMenu sel |
	aMenu _ MVCMenuMorph new.
	aMenu defaultTarget: aMenu.
	openForEditing
		ifTrue:
			[aMenu add: 'resume being a parts bin' selector: #selectMVCItem: argument:	#toggleStatus]
		ifFalse:
			[aMenu add: 'open for editing' selector: #selectMVCItem: argument:#toggleStatus].
	aMenu add: 'sort pages'	selector: #selectMVCItem: argument: #sortPages.
	aMenu add: 'save as Custom Parts Bin' selector: #selectMVCItem: argument: #saveAsCustomPartsBin.
	sel _ aMenu invokeAt: self primaryHand position in: self world.
	sel ifNotNil: [self perform: sel].
