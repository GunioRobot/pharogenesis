boardLocAt: cellPoint

	| dx dy row col |
	dx _ self width/15.0.  dy _ dx * 0.8660254037844385 "(Float pi / 3) sin".
	row _ (cellPoint y - self position y) // dy + 1.
	col _ (cellPoint x - self position x) / (dx/2.0) + 16 - row // 2.
	^ row @ col