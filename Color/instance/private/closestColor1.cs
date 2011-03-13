closestColor1
	"Return the nearest approximation to this color for a monochrome Form.
	Should this be based on r+g+b?  Should it be L. lightness, in L*a*b* space? 6/14/96 tk"

	self halt. "old"
	self brightness > 0.5
		ifTrue: [ ^ 0 ]
		ifFalse: [ ^ 1 ].