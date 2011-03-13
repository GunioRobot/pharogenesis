performanceTestFullRequires
	self prepareAllCaches.
	"note that we do not invalidate any caches"
	self measure: [AlignmentMorph requiredSelectors].
	"assuming we want 5 browsers to update their requiredSelectors list in 0.1 second"
	self assert: realTime < 20