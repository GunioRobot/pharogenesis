morphTo: ratio
	| srcShape dstShape morphShape |
	1 to: morphShapes size do:[:i|
		srcShape := srcShapes at: i.
		dstShape := dstShapes at: i.
		morphShape := morphShapes at: i.
		morphShape morphFrom: srcShape to: dstShape at: ratio].		