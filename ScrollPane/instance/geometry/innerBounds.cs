innerBounds
	| inner w |
	inner _ super innerBounds.
	w _ self scrollbarWidth.
	retractableScrollBar | (submorphs includes: scrollBar) not
		ifTrue: [^ inner]
		ifFalse: [^ (scrollBarOnLeft
					ifTrue: [inner topLeft + ((w-1)@0) corner: inner bottomRight]
					ifFalse: [inner topLeft corner: inner bottomRight - ((w-2)@0)])]