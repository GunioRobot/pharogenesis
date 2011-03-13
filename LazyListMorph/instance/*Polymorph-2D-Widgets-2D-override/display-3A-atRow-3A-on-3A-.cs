display: item  atRow: row on: aCanvas
	"Display the given item at the given row on the given canvas."
	
	| c drawBounds frame attrs useDefaultFont|
	drawBounds := self drawBoundsForRow: row.
	c := self colorForRow: row.
	item isText
		ifTrue: [|f col itemBounds|
				attrs := item attributesAt: 1 forStyle: TextStyle default.
				useDefaultFont := true.
				attrs do: [:att | att forFontInStyle: TextStyle default do: [:fon | useDefaultFont := false]].
				f := useDefaultFont
					ifTrue: [self font]
					ifFalse: [item fontAt: 1 withStyle: TextStyle default].
				col := (item attributesAt: 1) detect: [:a | a isKindOf: TextColor] ifNone: [].
				col ifNotNil: [c := col color].
				itemBounds := drawBounds withHeight: f height.
				itemBounds := itemBounds align: itemBounds leftCenter with: drawBounds leftCenter.
					"centre the item if the font height is different to that of our font"
				aCanvas drawString: item in: itemBounds font: (f emphasized: (item emphasisAt: 1)) color: c underline: ((item emphasisAt: 1) bitAnd: 4) > 0 underlineColor: c strikethrough: ((item emphasisAt: 1) bitAnd: 16) > 0 strikethroughColor: c]
		ifFalse: [aCanvas drawString: item in: drawBounds font: self font color: c].
	row = ((self respondsTo: #mouseDownRow) "check since MC doesn't manage an atomic load!"
			ifTrue: [self mouseDownRow])
		ifTrue: [frame := self selectionFrameForRow: row.
				aCanvas 
					frameRectangle: frame
					width: 1
					colors: {c. Color transparent}
					 dashes: #(1 1)]