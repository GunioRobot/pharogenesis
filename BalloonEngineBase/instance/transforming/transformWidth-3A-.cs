transformWidth: w
	"Transform the given width"
	| deltaX deltaY dstWidth dstWidth2 |
	self inline: false.
	self var: #deltaX declareC:'double deltaX'.
	self var: #deltaY declareC:'double deltaY'.
	w = 0 ifTrue:[^0].
	self point1Get at: 0 put: 0.
	self point1Get at: 1 put: 0.
	self point2Get at: 0 put: w * 256.
	self point2Get at: 1 put: 0.
	self point3Get at: 0 put: 0.
	self point3Get at: 1 put: w * 256.
	self transformPoints: 3.
	deltaX _ ((self point2Get at: 0) - (self point1Get at: 0)) asFloat.
	deltaY _ ((self point2Get at: 1) - (self point1Get at: 1)) asFloat.
	dstWidth _ (((deltaX * deltaX) + (deltaY * deltaY)) sqrt asInteger + 128) // 256.
	deltaX _ ((self point3Get at: 0) - (self point1Get at: 0)) asFloat.
	deltaY _ ((self point3Get at: 1) - (self point1Get at: 1)) asFloat.
	dstWidth2 _ (((deltaX * deltaX) + (deltaY * deltaY)) sqrt asInteger + 128) // 256.
	dstWidth2 < dstWidth ifTrue:[dstWidth _ dstWidth2].
	dstWidth = 0
		ifTrue:[^1]
		ifFalse:[^dstWidth]