initPool
	"BalloonEngineBase initPool"
	(Smalltalk includesKey: #BalloonEngineConstants) ifFalse:[
		Smalltalk declare: #BalloonEngineConstants from: Undeclared.
	].
	(Smalltalk at: #BalloonEngineConstants) isNil ifTrue:[
		(Smalltalk associationAt: #BalloonEngineConstants) value: Dictionary new.
	].
	self initPool: (Smalltalk at: #BalloonEngineConstants).