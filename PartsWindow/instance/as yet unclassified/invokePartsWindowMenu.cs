invokePartsWindowMenu
	| aMenu sel |
	aMenu _ MVCMenuMorph new.
	openForEditing
		ifTrue:
			[aMenu add: 'resume being a parts bin' action:	#toggleStatus]
		ifFalse:
			[aMenu add: 'open for editing'			action:	#toggleStatus].
	aMenu add: 'sort pages'	action: #sortPages.
	aMenu add: 'save as Custom Parts Bin' action: #saveAsCustomPartsBin.
	sel _ aMenu invokeAt: self primaryHand position in: self world.
	sel ifNotNil: [self perform: sel].
