initialize
	super initialize.

	altText _ '[image]'.
	self color: Color transparent.
	downloadQueue _ SharedQueue new.