flipAroundY
	bounds _ (bounds origin x @ bounds corner y negated) corner:
				(bounds corner x @ bounds origin y negated).
	contours _ self contours collect:[:contour| contour collect:[:pt| pt x @ pt y negated]].