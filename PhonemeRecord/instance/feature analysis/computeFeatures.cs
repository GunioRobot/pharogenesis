computeFeatures
	"Compute and record a features vector take from the start of my samples. This method is typically used to analyze a single buffer during recognition."

	self features: (self extractFeaturesAt: 1).
