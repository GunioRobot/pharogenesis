pickingMatrixFor: vp at: aPoint extent: extentPoint
	"Return a matrix for picking at the given point using the given extent."
	| m scaleX scaleY ofsX ofsY |
	scaleX _ vp width / extentPoint x.
	scaleY _ vp height / extentPoint y.
	ofsX _ (vp width + (2.0 * (vp origin x - aPoint x))) / extentPoint x.
	ofsY _ (vp height + (2.0 * (aPoint y - vp corner y))) / extentPoint y.
	m _ B3DMatrix4x4 identity.
	m a11: scaleX; a22: scaleY.
	m a14: ofsX; a24: ofsY.
	^m