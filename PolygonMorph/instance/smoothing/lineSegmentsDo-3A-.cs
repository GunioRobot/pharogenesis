lineSegmentsDo: endPointsBlock 
	"Emit a sequence of segment endpoints into endPointsBlock."

	| n t x y x1 x2 x3 y1 y2 y3 beginPoint endPoint cs |
	smoothCurve 
		ifFalse: 
			[beginPoint := nil.
			vertices do: 
					[:vert | 
					beginPoint ifNotNil: [endPointsBlock value: beginPoint value: vert].
					beginPoint := vert].
			(closed or: [vertices size = 1]) 
				ifTrue: [endPointsBlock value: beginPoint value: vertices first].
			^self].

	"For curves we include all the interpolated sub segments."
	vertices size < 1 ifTrue: [^self].
	cs := self coefficients.
	beginPoint := (x := cs first first) @ (y := cs fifth first).
	1 to: cs first size - 1
		do: 
			[:i | 
			"taylor series coefficients"

			x1 := cs second at: i.
			y1 := cs sixth at: i.
			x2 := (cs third at: i) / 2.0.
			y2 := (cs seventh at: i) / 2.0.
			x3 := (cs fourth at: i) / 6.0.
			y3 := ((cs eighth) at: i) / 6.0.
			"guess n"
			n := 5 
						max: (((x2 abs + y2 abs) * 2.0 + (cs third at: i + 1) abs 
								+ (cs seventh at: i + 1) abs) / 100.0) 
								rounded.
			1 to: n - 1
				do: 
					[:j | 
					t := j asFloat / n.
					endPoint := (((x3 * t + x2) * t + x1) * t + x) 
								@ (((y3 * t + y2) * t + y1) * t + y).
					endPointsBlock value: beginPoint value: endPoint.
					beginPoint := endPoint].
			endPoint := (x := cs first at: i + 1) @ (y := cs fifth at: i + 1).
			endPointsBlock value: beginPoint value: endPoint.
			beginPoint := endPoint]