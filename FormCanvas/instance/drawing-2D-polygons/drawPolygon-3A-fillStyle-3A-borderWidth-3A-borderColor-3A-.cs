drawPolygon: vertices fillStyle: aFillStyle borderWidth: bw borderColor: bc
	"Use a BalloonCanvas"
	self asBalloonCanvas 
		drawPolygon: vertices 
		fillStyle: (self shadowColor ifNil:[aFillStyle])
		borderWidth: bw 
		borderColor: bc