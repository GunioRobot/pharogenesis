intersectFrom: pt1Start to: pt1End with: pt2Start to: pt2End
	| det deltaPt alpha beta pt1Dir pt2Dir |
	pt1Dir _ pt1End - pt1Start.
	pt2Dir _ pt2End - pt2Start.
	det _ (pt1Dir x * pt2Dir y) - (pt1Dir y * pt2Dir x).
	deltaPt _ pt2Start - pt1Start.
	alpha _ (deltaPt x * pt2Dir y) - (deltaPt y * pt2Dir x).
	beta _ (deltaPt x * pt1Dir y) - (deltaPt y * pt1Dir x).
	det = 0 ifTrue:[^nil]. "no intersection"
	alpha * det < 0 ifTrue:[^nil].
	beta * det < 0 ifTrue:[^nil].
	det > 0 
		ifTrue:[(alpha > det or:[beta > det]) ifTrue:[^nil]]
		ifFalse:[(alpha < det or:[beta < det]) ifTrue:[^nil]].
	"And compute intersection"
	^pt1Start + (alpha * pt1Dir / (det@det))