popMenu
	| aMenu |
	aMenu := menu removeLast.
	n removeLast.
	self styleMenu: aMenu.
	^ aMenu