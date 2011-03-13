isFulfilled
	"Are all my required releases already installed?"
	
	^requiredReleases allSatisfy: [:r | r isInstalled ]