flipVAroundY: centerY
	"Flip me vertically around the center.  If centerY is nil, compute my center of gravity."

	| cent |
	cent _ centerY 
		ifNil: [bounds center y
			"cent _ 0.
			vertices do: [:each | cent _ cent + each y].
			cent asFloat / vertices size"]		"average is the center"
		ifNotNil: [centerY].
	self setVertices: (vertices collect: [:vv |
			vv x @ ((vv y - cent) * -1 + cent)]) reversed.