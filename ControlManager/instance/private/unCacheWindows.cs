unCacheWindows
	scheduledControllers ifNotNil: [scheduledControllers do:
		[:aController | aController view uncacheBits]]