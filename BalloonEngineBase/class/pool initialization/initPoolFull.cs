initPoolFull	"BalloonEngineBase initPoolFull"
	"Move old stuff to Undeclared and re-initialize the receiver"
	BalloonEngineConstants associationsDo:[:assoc|
		Undeclared declare: assoc key from: BalloonEngineConstants.
	].
	self initPool.
	Undeclared removeUnreferencedKeys.