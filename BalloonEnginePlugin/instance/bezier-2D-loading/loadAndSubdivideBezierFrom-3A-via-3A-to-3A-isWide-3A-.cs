loadAndSubdivideBezierFrom: point1 via: point2 to: point3 isWide: wideFlag
	"Load and subdivide the bezier curve from point1/point2/point3.
	If wideFlag is set then make sure the curve is monoton in X."
	| bz1 bz2 index2 index1 |
	self inline: false.
	self var: #point1 declareC:'int *point1'.
	self var: #point2 declareC:'int *point2'.
	self var: #point3 declareC:'int *point3'.
	bz1 _ self allocateBezierStackEntry.	
	engineStopped ifTrue:[^0].
	"Load point1/point2/point3 on the top of the stack"
	self bzStartX: bz1 put: (point1 at: 0).
	self bzStartY: bz1 put: (point1 at: 1).
	self bzViaX: bz1 put: (point2 at: 0).
	self bzViaY: bz1 put: (point2 at: 1).
	self bzEndX: bz1 put: (point3 at: 0).
	self bzEndY: bz1 put: (point3 at: 1).

	"Now check if the bezier curve is monoton. If not, subdivide it."
	index2 _ bz2 _ self subdivideToBeMonoton: bz1 inX: wideFlag.
	bz1 to: bz2 by: 6 do:[:index|
		index1 _ self subdivideBezierFrom: index.
		index1 > index2 ifTrue:[index2 _ index1].
		engineStopped ifTrue:[^0]. "Something went wrong"
	].
	"Return the number of segments"
	^index2 // 6