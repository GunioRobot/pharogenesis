cellPointAt: boardLoc
	| dx dy row col |
	dx _ self width/15.0.  dy _ dx * 0.8660254037844385 "(Float pi / 3) sin".
	row _ boardLoc x.
	col _ boardLoc y.
	^ self position + ((col*2+row-16*dx//2)@(row-1*dy)) asIntegerPoint