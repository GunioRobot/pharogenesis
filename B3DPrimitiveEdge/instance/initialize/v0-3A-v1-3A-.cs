v0: vtx0 v1: vtx1
	v0 _ vtx0.
	v1 _ vtx1.
	flags _ 0.
	nLines _ (vtx1 windowPosY bitShift: -12) - (vtx0 windowPosY bitShift: -12).