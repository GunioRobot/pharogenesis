displayForm: f
	| width height depth bits realForm simDisp realDisp |
	bits _ self fetchPointer: 0 ofObject: f.
	width _ self fetchInteger: 1 ofObject: f.
	height _ self fetchInteger: 2 ofObject: f.
	depth _ self fetchInteger: 3 ofObject: f.
	realForm _ Form extent: width@height depth: depth.
	simDisp _ Form new hackBits: memory.
	realDisp _ Form new hackBits: realForm bits.
	realDisp
		copy: (0 @ 0 extent: 4 @ realForm bits size)
		from: (0 @ (bits + 4 // 4))
		in: simDisp
		rule: Form over.
	realForm displayOn: Display at: 0@0.