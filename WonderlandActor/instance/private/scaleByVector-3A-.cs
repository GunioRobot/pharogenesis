scaleByVector: aVector
	"Scale the object by the given vector."

	| aMatrix |
	aMatrix _ B3DMatrix4x4 identity.

	"Scale my matrix"
	aMatrix scalingX: (aVector x) y: (aVector y) z: (aVector z).
	scaleMatrix _ aMatrix composeWith: scaleMatrix.

	"Now scale my parts"
	myChildren do: [:child | (child isPart) ifTrue: [
								child setPositionVector: (child getPositionVector) * aVector.
								child scaleByVector: aVector
												].
					].
