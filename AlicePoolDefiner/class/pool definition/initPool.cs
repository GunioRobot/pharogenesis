initPool
	"Create the pool dictionary if necessary"

	| poolName |
	poolName _ #AliceConstants.
	(Smalltalk includesKey: poolName) ifFalse:[
		Smalltalk declare: poolName from: Undeclared.
	].

	(Smalltalk at: poolName) isNil ifTrue:[
		(Smalltalk associationAt: poolName)
				value: ((Smalltalk at: #WonderlandConstants) copy).
	].

	self initPool: (Smalltalk at: poolName).