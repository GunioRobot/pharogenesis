initPoolFull	"B3DPoolDefiner initPoolFull"
	"Move old stuff to Undeclared and re-initialize the receiver"
	| pool |
	pool _ Smalltalk at: self poolName asSymbol ifAbsent:[Dictionary new].
	pool associationsDo:[:assoc|
		Undeclared declare: assoc key from: pool.
	].
	self initPool.
	Undeclared removeUnreferencedKeys.