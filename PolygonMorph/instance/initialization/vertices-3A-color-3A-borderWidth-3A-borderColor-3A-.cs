vertices: verts color: aColor borderWidth: borderWidthInteger borderColor: anotherColor 
	super initialize.
""
	vertices _ verts.
	color _ aColor.
	borderWidth _ borderWidthInteger.
	borderColor _ anotherColor.
	closed _ vertices size > 2.
	arrows _ #none.
	self computeBounds