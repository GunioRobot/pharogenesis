nextPutRGB: aForm
	| myType peeker f shift mask |
	cols _ aForm width.
	rows _ aForm height.
	depth _ aForm depth.
	f _ aForm.
	depth < 16 ifTrue:[
		f _ aForm asFormOfDepth: 32.
		depth _ 32.
	].
	myType _ $6.
	"stream position: 0."
	self writeHeader: myType.
	depth = 32 ifTrue:[shift _ 8. mask _ 16rFF] ifFalse:[shift _ 5. mask _ 16r1F].
	peeker _ BitBlt current bitPeekerFromForm: f.
	0 to: rows-1 do: [:y |
		0 to: cols-1 do: [:x | | p r g b |
			p _ peeker pixelAt: x@y.
			b _ p bitAnd: mask. p _ p >> shift.
			g _ p bitAnd: mask. p _ p >> shift.
			r _ p bitAnd: mask.
			stream nextPut: r.
			stream nextPut: g.
			stream nextPut: b.
		]
	].
