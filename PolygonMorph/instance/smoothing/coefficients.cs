coefficients
	"Compute an array for the coefficients.  This is copied from Flegal's old
	code in the Spline class."

	| length extras verts coefficients |
	curveState ifNotNil: [^curveState first].
	verts := closed 
				ifTrue: [vertices copyWith: vertices first]
				ifFalse: [vertices].
	length := verts size.
	extras := 0.
	coefficients := Array new: 8.
	1 to: 8 do: [:i | coefficients at: i put: (Array new: length + extras)].
	1 to: 5
		by: 4
		do: 
			[:k | 
			1 to: length
				do: 
					[:i | 
					(coefficients at: k) at: i
						put: (k = 1 
								ifTrue: [(verts at: i) x asFloat]
								ifFalse: [(verts at: i) y asFloat])].
			1 to: extras
				do: 
					[:i | 
					(coefficients at: k) at: length + i put: ((coefficients at: k) at: i + 1)].
			self 
				derivs: (coefficients at: k)
				first: (coefficients at: k + 1)
				second: (coefficients at: k + 2)
				third: (coefficients at: k + 3)].
	extras > 0 
		ifTrue: 
			[1 to: 8
				do: 
					[:i | 
					coefficients at: i put: ((coefficients at: i) copyFrom: 2 to: length + 1)]].
	curveState := { 
				coefficients.
				nil.
				nil}.
	self computeNextToEndPoints.
	^coefficients