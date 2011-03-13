startUp: resuming
	resuming 
		ifTrue:[
			self current 
				clearBitBltSubPixelAvailable;
				clearForceNonSubPixelCount]