features
	"Answer the features vector for this phoneme, an array of numbers used in the phoneme matching process. Compute the features if necessary."

	features ifNil: [
		AverageFeatures
			ifTrue: [features := self averageFeatures]
			ifFalse: [features := self featuresAtCenter]].
	^ features
