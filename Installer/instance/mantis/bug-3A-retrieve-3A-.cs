bug: aBugNo retrieve: aFileName

	 self setBug: aBugNo.

	^ (self maStreamForFile: aFileName) contents