features
	"Answer the features vector for this phoneme, an array of numbers used in the phoneme matching process. Compute the features if necessary."

	features ifNil: [
		AverageFeatures
			ifTrue: [features _ self averageFeatures]
			ifFalse: [features _ self featuresAtCenter]].
	^ features
