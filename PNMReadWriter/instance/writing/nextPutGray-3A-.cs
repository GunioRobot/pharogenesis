nextPutGray: aForm
	| myType peeker val |
	cols _ aForm width.
	rows _ aForm height.
	depth _ aForm depth.
	"stream position: 0."
	aForm depth = 1 ifTrue:[myType _ $4] ifFalse:[myType _ $5].
	self writeHeader: myType.
	peeker _ BitBlt current bitPeekerFromForm: aForm.
	0 to: rows-1 do: [:y |
		0 to: cols-1 do: [:x |
			val _ peeker pixelAt: x@y.
			stream nextPut: val.
		]
	].
