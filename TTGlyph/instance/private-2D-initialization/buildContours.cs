buildContours
	"Build the contours in the receiver glyph.
	The contour is constructed by converting the points
	form each contour into an absolute value and then
	compressing the contours into PointArrays."
	| tx ty points |
	tx _ ty _ 0.
	contours _ contours collect:[:contour|
		points _ contour points.
		points do:[:pt|
			pt x: (tx _ tx + pt x).
			pt y: (ty _ ty + pt y)].
		contour asCompressedPoints].