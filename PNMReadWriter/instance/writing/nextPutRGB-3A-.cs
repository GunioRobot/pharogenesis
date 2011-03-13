nextPutRGB: aForm 
	| myType peeker f shift mask |
	cols := aForm width.
	rows := aForm height.
	depth := aForm depth.
	f := aForm.
	depth < 16 ifTrue: 
		[ f := aForm asFormOfDepth: 32.
		depth := 32 ].
	myType := $6.
	"stream position: 0."
	self writeHeader: myType.
	depth = 32 
		ifTrue: 
			[ shift := 8.
			mask := 255 ]
		ifFalse: 
			[ shift := 5.
			mask := 31 ].
	peeker := BitBlt current bitPeekerFromForm: f.
	0 
		to: rows - 1
		do: 
			[ :y | 
			0 
				to: cols - 1
				do: 
					[ :x | 
					| p r g b |
					p := peeker pixelAt: x @ y.
					b := p bitAnd: mask.
					p := p >> shift.
					g := p bitAnd: mask.
					p := p >> shift.
					r := p bitAnd: mask.
					stream nextPut: r.
					stream nextPut: g.
					stream nextPut: b ] ]