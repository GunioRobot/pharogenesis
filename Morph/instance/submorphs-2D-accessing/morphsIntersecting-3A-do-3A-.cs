morphsIntersecting: aRectangle do: morphBlock
	"Perform a display-order traversal of morphic structure,
	evaluating aBlock for every morph that intersects aRectangle.
	NOTE: this code is fast and conservative -- clients must refine
	with, eg, containsPoint:, as this method only considers bounds."

	(aRectangle intersects: self fullBounds) ifFalse: [^ self].
	(aRectangle intersects: bounds) ifTrue: [morphBlock value: self].
	submorphs size > 0 ifTrue:
		[submorphs reverseDo:
			[:m | m morphsIntersecting: aRectangle do: morphBlock]]