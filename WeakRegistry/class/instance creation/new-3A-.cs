new: n
	| registry |
	registry := super new initialize: n.
	WeakArray addWeakDependent: registry.
	^registry