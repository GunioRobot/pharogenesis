initPool: aDictionary
	self initStateConstants: aDictionary.
	self initWorkBufferConstants: aDictionary.
	self initPrimitiveConstants: aDictionary.
	self initEdgeConstants: aDictionary.
	self initFillConstants: aDictionary.
	self initializeInstVarNames: BalloonEngine in: aDictionary prefixedBy: 'BE'.
	self initializeInstVarNames: BalloonEdgeData in: aDictionary prefixedBy: 'ET'.
	self initializeInstVarNames: BalloonFillData in: aDictionary prefixedBy: 'FT'.