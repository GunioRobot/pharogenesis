loadCachedResources
	"Load all the resources that we have cached locally"
	| resource |
	self class reloadCachedResources.
	self prioritizedUnloadedResources do:[:loc|
		self class lookupCachedResource: loc urlString ifPresentDo:[:stream|
			resource _ resourceMap at: loc ifAbsent:[nil].
			self installResource: resource
				from: stream
				locator: loc.
			(resource isForm) ifTrue:[
				self formChangedReminder value.
				World displayWorldSafely].
		].
	].