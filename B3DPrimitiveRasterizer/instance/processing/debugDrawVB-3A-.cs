debugDrawVB: vb
	| vtx idx1 idx2 idx3 v1 v2 v3 vp myCanvas |
	myCanvas _ target getCanvas.
	vp _ viewport clone.
	vtx _ Array new: vb vertexCount.
	vb vertexArray upTo: vb vertexCount doWithIndex:[:v :i|
		vtx at: i put: (vp mapVertex4: v rasterPos).
	].
	1 to: vb indexCount-1 by: 3 do:[:i|
		idx1 _ vb indexArray at: i.
		idx2 _ vb indexArray at: i+1.
		idx3 _ vb indexArray at: i+2.
		idx1 = 0 ifFalse:[
			v1 _ vtx at: idx1.
			v2 _ vtx at: idx2.
			v3 _ vtx at: idx3.
			myCanvas line: v1 to: v2 width: 1 color: Color black.
			myCanvas line: v2 to: v3 width: 1 color: Color black.
			myCanvas line: v3 to: v1 width: 1 color: Color black.
		].
	].