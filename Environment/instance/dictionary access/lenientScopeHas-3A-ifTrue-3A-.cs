lenientScopeHas: varName ifTrue: assocBlock
	"Compatibility hack -- find things in sub environments for now"
	| assoc envt |
	(assoc _ self associationAt: varName ifAbsent: []) == nil
		ifFalse: [assocBlock value: assoc.
				^ true].

	self associationsDo:
		[:assn | (((envt _ assn value) isKindOf: Environment) and: [envt ~~ self])
			ifTrue: [(envt lenientScopeHas: varName ifTrue: assocBlock)
						ifTrue: [^ true]]].
	^ false