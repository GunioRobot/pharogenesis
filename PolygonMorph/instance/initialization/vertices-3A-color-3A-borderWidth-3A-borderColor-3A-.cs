vertices: verts color: c borderWidth: bw borderColor: bc
	super initialize.
	vertices _ verts.
	color _ c.
	borderWidth _ bw.
	borderColor _ bc.
	closed _ vertices size > 2.
	quickFill _ true.
	arrows _ #none.
	self computeBounds.
