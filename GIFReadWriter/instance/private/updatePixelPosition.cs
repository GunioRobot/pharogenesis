updatePixelPosition
	(xpos _ xpos + 1) >= width ifFalse: [^self].
	xpos _ 0.
	interlace
		ifFalse: [ypos _ ypos + 1. ^self].
	pass = 0 ifTrue:
		[(ypos _ ypos + 8) >= height
			ifTrue:
				[pass _ pass + 1.
				ypos _ 4].
		^self].
	pass = 1 ifTrue:
		[(ypos _ ypos + 8) >= height
			ifTrue:
				[pass _ pass + 1.
				ypos _ 2].
		^self].
	pass = 2 ifTrue:
		[(ypos _ ypos + 4) >= height
			ifTrue:
				[pass _ pass + 1.
				ypos _ 1].
		^self].
	pass = 3 ifTrue:
		[ypos _ ypos + 2.
		^self].

	^self error: 'can''t happen'