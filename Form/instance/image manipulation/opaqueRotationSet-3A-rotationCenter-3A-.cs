opaqueRotationSet: steps rotationCenter: aPoint
	"CAUTION:  this returns the set in counterclockwise order from north-pointing.  For the HyperSqueak work of 6/96, the assumption is that they come in clockwise order, and so a fudging routine, SqueakSupport.reversedFormSetFrom:, is provided.  Someday this should be cleaned up.
	8/8/96 sw: this variant has a rotationCenter argument, though at the moment it is not used.  It will come in as nil if there is no special center, in which case the centroid of the form should be used, as it always is in the current implementation."

	| drawing  back90 flip quad |

	self flag: #noteToTed.  "This at the moment is the same as what you fixed up a couple of months ago, and does not actually use the rotationCenter part.  8/9/96 sw"

	drawing _ Array new: steps.

	steps \\ 4 = 0 ifFalse: ["Can't pull any symmetry tricks, rotate every one"
		1 to: steps do: [:ind |
			drawing at: ind put: (self rotateBy: 360 - ((ind-1) * 360 // steps))].
			^ drawing].
	"Do in four sections"
	quad _ steps // 4.
	1 to: quad do: [:ind |		"degrees: 360, 330, 300"
			drawing at: ind put: (self rotateBy: 360 - ((ind-1)*360//steps))].
	1 to: quad do: [:ind |		"degrees: 270, 240, 210"
			back90 _ drawing at: ind.
			drawing at:  ind + quad put: (back90 rotateBy: #left centerAt: back90 center)].
	1 to: quad + quad do: [:ind |	"the entire second half circle is rotated 180"
			back90 _ drawing at: ind.
			flip _ back90 flipBy: #vertical centerAt: back90 center. 
			drawing at: ind + quad + quad put: (flip flipBy: #horizontal centerAt: flip center)]. 

	^ drawing collect: [:elem |
		elem offset: 0@0. 
		MaskedForm transparentBorder: elem]