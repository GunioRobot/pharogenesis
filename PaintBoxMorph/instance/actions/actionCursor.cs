actionCursor
	"Return the cursor to use with this painting action/tool.  Offset of the form must be set."

| f c old map width co |
action == #paint: ifTrue: ["Make a cursor from the brush and the color"
	old _ self getNib.
	f _ ColorForm extent: old extent depth: 8.
	old displayOn: f at: old offset negated.
	map _ Color indexedColors copy.
	map at: 1 put: Color transparent.
	c _ self getColor.
	c = Color white ifTrue: [c _ Color black].
	c isTransparent ifTrue: [c _ Color black].
	map at: 2 put: c.
	f colors: map.
	f offset: f extent // 2.	"Morphic thinks of it backwards"
	^ f].
action == #erase: ifTrue: ["Make a cursor from the cursor and the color"
	width _ self getNib width.
	co _ (currentCursor offset - (width//2@4)) max: (0@0).
	f _ ColorForm extent: (width@width) + currentCursor extent depth: 8.
	currentCursor displayOn: f at: currentCursor offset "<- stet" negated "0@0".	
	f colors: currentCursor colors.
	f fill: (co extent: (width@width)) fillColor: Color black.
	f offset: co + (width@width //2).
	^ f].

^ currentCursor