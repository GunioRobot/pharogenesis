initPool
	"B3DPoolDefiner initPool"
	| poolName |
	poolName _ self poolName asSymbol.
	(Smalltalk includesKey: poolName) ifFalse:[
		Smalltalk declare: poolName from: Undeclared.
	].
	(Smalltalk at: poolName) isNil ifTrue:[
		(Smalltalk associationAt: poolName) value: Dictionary new.
	].
	self initPool: (Smalltalk at: poolName).