offerWindowMenu
	| aMenu |
	aMenu _ self buildWindowMenu.
	model ifNotNil:
		[model addModelItemsToWindowMenu: aMenu].
	aMenu popUpEvent: self currentEvent in: self world