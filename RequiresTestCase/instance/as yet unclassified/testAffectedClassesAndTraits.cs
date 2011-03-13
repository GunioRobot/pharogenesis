testAffectedClassesAndTraits
	| rscc |
	self setUpHierarchy.
	rscc := RequiredSelectorsChangesCalculator onModificationOf: {tb} withTargets: {ta. cg. ci. cd. tc}.
	self assert: rscc rootClasses asSet = (Set withAll: {cc. cb}).
	self assert: rscc classesToUpdate asSet = (Set withAll: {cg. cd. cf. cc. cb}).
	self assert: rscc traitsToUpdate asSet = (Set withAll: {tc}).
	self assert: (#(sscc) copyWithoutAll: (rscc selectorsToUpdateIn: cc)) isEmpty.
	self assert: (#(ssca) copyWithoutAll: (rscc selectorsToUpdateIn: cb)) isEmpty.