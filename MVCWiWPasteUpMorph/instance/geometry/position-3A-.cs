position: aPoint
	"Change the position of this morph and and all of its submorphs."

	| delta |
	delta _ aPoint - bounds topLeft.
	(delta x = 0 and: [delta y = 0]) ifTrue: [^ self].  "Null change"
	self changed.
	self privateFullMoveBy: delta.
	self changed.
