releaseCachedState
	| bg |
	bg _ self valueOfProperty: #backgroundSnapshot.
	bg == nil ifTrue:[^self].
	self setProperty: #backgroundSnapshot toValue: (Form extent: 1@1).
