actionCursor
	"Return the cursor to use with this painting action/tool. Offset of the form must be set."

	| ff c old map width co larger box |
	action == #paint: ifTrue: ["Make a cursor from the brush and the color"
		old _ self getNib.
		ff _ ColorForm extent: old extent depth: 1.
		old displayOn: ff at: old offset negated.
		c _ self getColor.
		c = Color white ifTrue: [c _ Color black].
		c isTransparent ifTrue: [c _ Color black].
		map _ ff colors.
		map at: (Color white indexInMap: map) put: Color transparent.
		map at: (Color black indexInMap: map) put: c.
		ff colors: map.
		ff offset: ff extent // 2.
		^ ff].
	action == #erase: ifTrue: ["Make a cursor from the cursor and the color"
		width _ self getNib width.
		co _ (currentCursor offset - (width//2@4)) max: (0@0).
		larger _ 0@0 extent: currentCursor extent + (width@width).
		ff _ currentCursor copy: larger.
		ff fill: (box _ co extent: (width@width)) fillColor: (Color r: 0.5 g: 0.5 b: 1.0).
		ff fill: (box insetBy: 1@1) fillColor: Color transparent.
		ff offset: co + (width@width //2).
		^ ff].

	^ currentCursor
