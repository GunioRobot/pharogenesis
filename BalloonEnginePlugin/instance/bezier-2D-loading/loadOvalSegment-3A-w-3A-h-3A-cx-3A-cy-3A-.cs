loadOvalSegment: seg w: w h: h cx: cx cy: cy
	| x0 y0 x2 y2 x1 y1 |
	self inline: false.
	"Load start point of segment"
	x0 _ ((self circleCosTable at: seg * 2 + 0) * w asFloat + cx) asInteger.
	y0 _ ((self circleSinTable at: seg * 2 + 0) * h asFloat + cy) asInteger.
	self point1Get at: 0 put: x0.
	self point1Get at: 1 put: y0.
	"Load end point of segment"
	x2 _ ((self circleCosTable at: seg * 2 + 2) * w asFloat + cx) asInteger.
	y2 _ ((self circleSinTable at: seg * 2 + 2) * h asFloat + cy) asInteger.
	self point3Get at: 0 put: x2.
	self point3Get at: 1 put: y2.
	"Load intermediate point of segment"
	x1 _ ((self circleCosTable at: seg * 2 + 1) * w asFloat + cx) asInteger.
	y1 _ ((self circleSinTable at: seg * 2 + 1) * h asFloat + cy) asInteger.
	"NOTE: The intermediate point is the point ON the curve
	and not yet the control point (which is OFF the curve)"
	x1 _ (x1 * 2) - (x0 + x2 // 2).
	y1 _ (y1 * 2) - (y0 + y2 // 2).
	self point2Get at: 0 put: x1.
	self point2Get at: 1 put: y1.