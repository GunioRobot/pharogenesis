nextPutBW: aForm reverse: flagXor
	| myType val nBytes bytesRow |
	cols _ aForm width.
	rows _ aForm height.
	depth _ aForm depth.
	"stream position: 0."
	aForm depth = 1 ifTrue:[myType _ $4] ifFalse:[myType _ $5].
	self writeHeader: myType.
	stream binary.
	nBytes _ (cols/8) ceiling.
	bytesRow _ (cols/32) ceiling * 4.
	0 to: rows-1 do: [:y | | i |
		i _ 1 + (bytesRow*y).
		0 to: nBytes-1 do: [:x |
			val _ aForm bits byteAt: i.
			flagXor ifTrue:[val _ val bitXor: 16rFF].
			stream nextPut: val.
			i _ i+1.
		]
	].
