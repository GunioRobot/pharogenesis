triangulate
	"Return the full triangulation of the receiver"
	| firstPoly poly |
	"Create the triangle list"
	firstPoly _ self createPolygons.
	poly _ firstPoly.
	[poly == nil] whileFalse:[
		poly buildTerminalFan.
		poly _ poly next].
	^firstPoly