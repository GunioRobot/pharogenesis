drawPointerOn: aCanvas
	| ptr x r |
	ptr _ (cursor asInteger max: 1) min: data size.
	r _ self innerBounds.
	x _ r left + ptr - startIndex.
	((x >= r left) and: [x <= r right]) ifTrue: [
		aCanvas fillRectangle: (x@r top corner: x+1@r bottom) color: cursorColor].
