for: aUrl in: aLoader
	url _ self httpEncodeSafely: aUrl.
	loader _ aLoader.
	semaphore _ Semaphore new.