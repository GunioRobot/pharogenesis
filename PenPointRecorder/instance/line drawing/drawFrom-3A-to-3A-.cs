drawFrom: p1 to: p2
	"Overridden to skip drawing but track bounds of the region traversed."

	points ifNil: [points _ OrderedCollection with: p1].
	points addLast: p2