removeFromGlobalIncomingQueue: theActualObject

	self critical: [
		GlobalIncomingQueue _ self globalIncomingQueue reject: [ :each | 
			each second == theActualObject
		].
		self bumpUpdateCounter.
	].