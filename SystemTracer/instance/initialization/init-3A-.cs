init: aContext
	initialProcess _ Process forContext: aContext priority: Processor activePriority.
	self initOopMap.
	hashGenerator _ Random new.
	self clamp: self.
	self clamp: aContext sender.
	self initDict