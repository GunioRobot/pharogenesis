destroy
	super destroy.
	textures ifNotNil:[textures do:[:tex| tex destroy]].
	self primDestroyRenderer: handle.
	handle _ nil.
	textures _ target _ nil.
