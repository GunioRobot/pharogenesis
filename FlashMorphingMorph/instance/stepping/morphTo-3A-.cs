morphTo: ratio
	| srcShape dstShape morphShape |
	1 to: morphShapes size do:[:i|
		srcShape _ srcShapes at: i.
		dstShape _ dstShapes at: i.
		morphShape _ morphShapes at: i.
		morphShape morphFrom: srcShape to: dstShape at: ratio].		