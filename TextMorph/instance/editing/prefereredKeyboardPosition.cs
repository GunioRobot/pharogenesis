prefereredKeyboardPosition

	| default rects |
	default  _ (self bounds: self bounds in: World) topLeft.
	paragraph ifNil: [^ default].
	rects _ paragraph selectionRects.
	rects size = 0 ifTrue: [^ default].
	^ rects first topLeft.

	"^ (self bounds: self bounds in: World) topLeft."
