initialize
	externals _ OrderedCollection new: 100.
	span _ Bitmap new: 2048.
	bitBlt _ nil.
	self bitBlt: ((BitBlt toForm: Display) destRect: Display boundingBox; yourself).
	forms _ #().
	deferred _ false.