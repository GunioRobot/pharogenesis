intersectFrom: startPt with: startDir to: endPt with: endDir
	"Compute the intersection of two lines. Return nil if either
		* the intersection does not exist, or
		* the intersection is 'before' startPt, or
		* the intersection is 'after' endPt
	"
	| det deltaPt alpha beta |
	det _ (startDir x * endDir y) - (startDir y * endDir x).
	det = 0.0 ifTrue:[^nil]. "There's no solution for it"
	deltaPt _ endPt - startPt.
	alpha _ (deltaPt x * endDir y) - (deltaPt y * endDir x).
	beta _ (deltaPt x * startDir y) - (deltaPt y * startDir x).
	alpha _ alpha / det.
	beta _ beta / det.
	alpha < 0 ifTrue:[^nil].
	beta > 1.0 ifTrue:[^nil].
	"And compute intersection"
	^(startPt x + (alpha * startDir x)) @ (startPt y + (alpha * startDir y))