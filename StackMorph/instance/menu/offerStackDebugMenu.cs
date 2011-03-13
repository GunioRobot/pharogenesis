offerStackDebugMenu
	"Put up a menu offering debugging items for the stack"

	| aMenu |
	aMenu _ MenuMorph new defaultTarget: self.
	aMenu addTitle: 'Stack debugging'.
	aMenu addStayUpItem.
	aMenu addList: #(
		('reassess'								reassessBackgroundShape)
		('relax grip on variable names'			relaxGripOnVariableNames)
		('commit card data'						commitCardData)
		-
		('browse card uniclass'					browseCardClass)
		('inspect card'							inspectCurrentCard)
		('inspect background'					inspectCurrentBackground)
		('inspect stack'							inspectCurrentStack)).
	aMenu popUpInWorld: (self world ifNil: [self currentWorld])
