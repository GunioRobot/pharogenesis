setEmphasis: emphasisSymbol
	"Change the emphasis of the current selection."

	| oldAttributes attribute |
	oldAttributes _ paragraph text attributesAt: startBlock stringIndex forStyle: paragraph textStyle.
	(emphasisSymbol == #plain) 
		ifTrue:
			[attribute _ TextEmphasis normal]
		ifFalse:
			[attribute _ TextEmphasis perform: emphasisSymbol.
			oldAttributes do:
				[:att | (att dominates: attribute) ifTrue: [attribute turnOff]]].
	self replaceSelectionWith: (self selection addAttribute: attribute)