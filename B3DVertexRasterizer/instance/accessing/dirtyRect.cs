dirtyRect
	"If the dirtyRect is not known (e.g., not implemented by a particular rasterizer) return the full viewport"
	^dirtyRect ifNil:[viewport]