phonemeDistanceTo: otherPhoneme
	"Answer the distance in feature space between this phoneme and the given phoneme."

	^ self featureDistanceFrom: self features to: otherPhoneme features
