setBackfaceCulling: aSymbol
	"Set backface culling. aSymbol must be either #cw, #ccw or nil"
	self setProperty: #backfaceCulling toValue: aSymbol.