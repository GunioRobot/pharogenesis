deepAssociationsDo: assnBlock
	"Compatibility hack -- find things in sub environments for now"

	| envt |
	self associationsDo:
		[:assn |
		(((envt _ assn value) isKindOf: Environment) and: [envt ~~ self])
			ifTrue: [envt deepAssociationsDo: assnBlock]
			ifFalse: [assnBlock value: assn]]