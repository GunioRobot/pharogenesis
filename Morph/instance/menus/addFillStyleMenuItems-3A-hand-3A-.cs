addFillStyleMenuItems: aMenu hand: aHand
	"Add the items for changing the current fill style of the Morph"
	| menu |
	self canHaveFillStyles ifFalse:[^aMenu add: 'change color...' target: self action: #changeColor].
	menu _ MenuMorph new defaultTarget: self.
	self fillStyle addFillStyleMenuItems: menu hand: aHand from: self.
	menu addLine.
	menu add: 'solid fill' action: #useSolidFill.
	menu add: 'gradient fill' action: #useGradientFill.
	menu add: 'bitmap fill' action: #useBitmapFill.
	menu add: 'default fill' action: #useDefaultFill.
	aMenu add: 'fill style' subMenu: menu.
	"aMenu add: 'change color...' action: #changeColor"