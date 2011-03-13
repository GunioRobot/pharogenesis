rectified
	"Make the origin coordinates <= the corner coords, swapping where necessary.  7/16/96 sw"
	
	| oldOrigin oldCorner |
	oldOrigin _ origin.
	oldCorner _ corner.
	origin _ oldOrigin min: oldCorner.
	corner _ oldOrigin max: oldCorner

	" (100 @ 50 corner: 80 @ 25) rectified"