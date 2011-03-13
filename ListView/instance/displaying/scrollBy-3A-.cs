scrollBy: anInteger 
	"Scroll up by this amount adjusted by lineSpacing and list limits"
	| maximumAmount minimumAmount amount wasClipped |
	maximumAmount _ 0 max:
		list clippingRectangle top - list compositionRectangle top.
	minimumAmount _ 0 min:
		list clippingRectangle bottom - list compositionRectangle bottom.
	amount _ (anInteger min: maximumAmount) max: minimumAmount.
	amount ~= 0
		ifTrue: [list scrollBy: amount negated.  ^ true]
		ifFalse: [^ false]  "Return false if no scrolling took place"