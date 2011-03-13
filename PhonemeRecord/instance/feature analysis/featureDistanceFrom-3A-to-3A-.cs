featureDistanceFrom: featuresVec1 to: featuresVec2
	"Answer the distance between the given two feature vectors. The lower this value, the closer the phonemes match."

	| sumOfSquares |
	sumOfSquares := 0.
	1 to: featuresVec1 size do: [:i |
		 sumOfSquares := sumOfSquares +
			((featuresVec1 at: i) - (featuresVec2 at: i)) squared].
	^ sumOfSquares sqrt
