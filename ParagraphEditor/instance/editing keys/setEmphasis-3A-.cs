setEmphasis: emphasisSymbol
	"Change the emphasis of the current selection."

	| oldAttributes attribute |
	oldAttributes _ paragraph text attributesAt: self selectionInterval first forStyle: paragraph textStyle.

	attribute _ TextEmphasis perform: emphasisSymbol.
	(emphasisSymbol == #normal) 
		ifFalse:	[oldAttributes do:	
			[:att | (att dominates: attribute) ifTrue: [attribute turnOff]]].
	self replaceSelectionWith: (self selection addAttribute: attribute)