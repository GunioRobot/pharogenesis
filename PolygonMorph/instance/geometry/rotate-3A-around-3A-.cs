rotate: degrees around: centerPt
	"Rotate me around the center.  If center is nil, use the center of my bounds.  Rotation is clockwise on the screen."

	| cent |
	cent _ centerPt 
		ifNil: [bounds center]	"approx the center"
		ifNotNil: [centerPt].
	degrees \\ 90 = 0 ifTrue: ["make these cases exact"
		degrees \\ 360 = 90 ifTrue: ["right"
			^ self setVertices: (vertices collect: [:vv |
				(vv - cent) y * -1 @ ((vv - cent) x) + cent])].
		degrees \\ 360 = 180 ifTrue: [
			^ self setVertices: (vertices collect: [:vv |
				(vv - cent) negated + cent])].
		degrees \\ 360 = 270 ifTrue: ["left"
			^ self setVertices: (vertices collect: [:vv |
				(vv - cent) y @ ((vv - cent) x * -1) + cent])].
		degrees \\ 360 = 0 ifTrue: [^ self].
		].
	self setVertices: (vertices collect: [:vv |
			(Point r: (vv - cent) r degrees: (vv - cent) degrees + degrees) + cent]).