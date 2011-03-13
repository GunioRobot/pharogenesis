lineSegmentsDo: endPointsBlock
	"Emit a sequence of segment endpoints into endPointsBlock."
	| n t x y x1 x2 x3 y1 y2 y3 beginPoint endPoint cs |
	smoothCurve ifFalse:
		[beginPoint _ nil.
		vertices do:
			[:vert | beginPoint ifNotNil:
				[endPointsBlock value: beginPoint
								value: vert].
			beginPoint _ vert].
		(closed or: [vertices size = 1])
			ifTrue: [endPointsBlock value: beginPoint
									value: vertices first].
		^ self].

	"For curves we include all the interpolated sub segments."
	vertices size < 1 ifTrue: [^ self].
	cs _ self coefficients.
	beginPoint _ (x _ (cs at: 1) at: 1) @ (y _ (cs at: 5) at: 1).
	1 to: (cs at: 1) size - 1 do: 
		[:i |  "taylor series coefficients"
		x1 _ (cs at: 2) at: i.
		y1 _ (cs at: 6) at: i.
		x2 _ ((cs at: 3) at: i) / 2.0.
		y2 _ ((cs at: 7) at: i) / 2.0.
		x3 _ ((cs at: 4) at: i) / 6.0.
		y3 _ ((cs at: 8) at: i) / 6.0.
		"guess n"
		n _ 5 max: (x2 abs + y2 abs * 2.0 + ((cs at: 3) at: i+1) abs
									+ ((cs at: 7) at: i+1) abs / 100.0) rounded.
		1 to: n - 1 do: 
			[:j | 
			t _ j asFloat / n.
			endPoint _ (x3 * t + x2 * t + x1 * t + x) @ (y3 * t + y2 * t + y1 * t + y).
			endPointsBlock value: beginPoint
							value: endPoint.
			beginPoint _ endPoint].
		endPoint _ (x _ (cs at: 1) at: i+1) @ (y _ (cs at: 5) at: i+1).
		endPointsBlock value: beginPoint
						value: endPoint.
		beginPoint _ endPoint]