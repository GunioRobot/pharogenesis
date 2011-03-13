packages: aCollection
	packages _ Set new.
	packages addAll: aCollection.
	self changed: #packages