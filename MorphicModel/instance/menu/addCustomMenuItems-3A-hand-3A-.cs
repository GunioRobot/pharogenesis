addCustomMenuItems: aCustomMenu hand: aHandMorph

	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	model ifNotNil: [model addModelMenuItemsTo: aCustomMenu forMorph: self hand: aHandMorph].
	self isOpen ifTrue: [aCustomMenu add: 'close editing' action: #closeToEdits]
			ifFalse: [aCustomMenu add: 'open editing' action: #openToEdits].
