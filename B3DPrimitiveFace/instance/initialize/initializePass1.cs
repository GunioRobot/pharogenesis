initializePass1
	"Assume: v0 sortsBefore: v1 sortsBefore: v2"
	| area majorDz minorDz |
	self initializeDepthBounds. "Compute minZ/maxZ"
	"Compute the major and minor reference edges"
	majorDx _ v2 rasterPosX - v0 rasterPosX.
	majorDy _ v2 rasterPosY - v0 rasterPosY.
	minorDx _ v1 rasterPosX - v0 rasterPosX.
	minorDy _ v1 rasterPosY - v0 rasterPosY.

	"Compute the inverse area of the face"
	area _ (majorDx * minorDy) - (minorDx * majorDy).
	((area > -0.001) and:[area < 0.001])
		ifTrue:[oneOverArea _ 0.0]
		ifFalse:[oneOverArea _ 1.0 / area].
	"Compute dzdx and dzdy"
	majorDz _ v2 rasterPosZ - v0 rasterPosZ.
	minorDz _ v1 rasterPosZ - v0 rasterPosZ.
	dzdx _ oneOverArea * ((majorDz * minorDy) - (minorDz * majorDy)).
	dzdy _ oneOverArea * ((majorDx * minorDz) - (majorDz * minorDx)).
