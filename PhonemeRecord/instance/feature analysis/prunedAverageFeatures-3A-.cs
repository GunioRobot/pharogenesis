prunedAverageFeatures: featureVectors
	"Compute the average of the given collection of feature vectors, then discard the outliers and average the remainding feature vectors. The result is an average of the most typical feature vectors in the given collection."

	| centroid sum vectorsWithErrors filtered |
	"compute the average of all the feature vectors"
	centroid := (1 to: featureVectors first size) collect: [:i |
		sum := 0.
		1 to: featureVectors size do: [:j | sum := sum + ((featureVectors at: j) at: i)].
		(sum asFloat / featureVectors size) rounded].

	"sort vectors by their distance from the centroid"
	vectorsWithErrors := SortedCollection sortBlock: [:e1 :e2 | e1 last < e2 last].
	featureVectors do: [:v |
		vectorsWithErrors add: (Array with: v with: (self featureDistanceFrom: v to: centroid))].

	"reject outlying feature vectors"
	filtered := (1 to: (0.8 * vectorsWithErrors size) rounded)
		collect: [:i | (vectorsWithErrors at: i) first].

	"answer the average of the remaining feature vectors"
	^ (1 to: filtered first size) collect: [:i |
		sum := 0.
		1 to: filtered size do: [:j | sum := sum + ((filtered at: j) at: i)].
		(sum asFloat / filtered size) rounded].

