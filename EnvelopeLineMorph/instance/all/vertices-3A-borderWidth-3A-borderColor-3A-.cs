vertices: verts borderWidth: bw borderColor: bc
	super initialize.
	vertices _ verts.
	color _ Color transparent.
	borderWidth _ bw.
	borderColor _ bc.
	closed _ false.
	quickFill _ true.
	arrows _ #none.
	self computeBounds.
