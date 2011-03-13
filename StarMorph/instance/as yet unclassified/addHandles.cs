addHandles
	| handle strokeOrigin p |
	handles ifNotNil: [handles do: [:hh | hh delete]].
	strokeOrigin _ 0@0.
	vertices do: [:each | strokeOrigin _ strokeOrigin + each].
	strokeOrigin _ strokeOrigin // vertices size.	"average is the center"
	handles _ Array new: 2.
		handle _ EllipseMorph newBounds: (Rectangle center: strokeOrigin extent: 8@8)
				color: Color yellow.
		handle on: #mouseMove send: #dragVertex:fromHandle:vertIndex:
				to: self withValue: #center.
		self addMorph: handle.
	handles at: 1 put: handle.	"The center one!!"
		p _ vertices at: 2.	"an outside one"
		handle _ EllipseMorph newBounds: (Rectangle center: p + (borderWidth//2) extent: 8@8)
				color: Color yellow.
		handle on: #mouseMove send: #dragVertex:fromHandle:vertIndex:
				to: self withValue: #outside.
		self addMorph: handle.
	handles at: 2 put: handle.	"The outside one!!"
	self changed