initializeFrom: aCollector
	"Initialize the receiver from the given resource collector. None of the resources have been loaded yet, so make register all resources as unloaded."
	| newLoc |
	aCollector stubMap keysAndValuesDo:[:stub :res|
		newLoc _ stub locator.
		resourceMap at: newLoc put: res.
		"unloaded add: newLoc."
	].