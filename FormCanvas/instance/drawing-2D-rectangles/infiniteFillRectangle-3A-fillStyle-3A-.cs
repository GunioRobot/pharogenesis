infiniteFillRectangle: aRectangle fillStyle: aFillStyle

	| additionalOffset rInPortTerms clippedPort targetTopLeft clipOffset ex |

	"this is a bit of a kludge to get the form to be aligned where I *think* it should be.
	something better is needed, but not now"

	additionalOffset _ 0@0.
	ex _ aFillStyle form extent.
	rInPortTerms _ aRectangle translateBy: origin.
	clippedPort _ port clippedBy: rInPortTerms.
	targetTopLeft _ clippedPort clipRect topLeft truncateTo: ex.
	clipOffset _ rInPortTerms topLeft - targetTopLeft.
	additionalOffset _ (clipOffset \\ ex) - ex.
	^aFillStyle
		displayOnPort: clippedPort
		offsetBy: additionalOffset
