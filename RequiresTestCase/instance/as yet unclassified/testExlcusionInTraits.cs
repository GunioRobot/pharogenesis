testExlcusionInTraits
	self assert: ((self requiredMethodsForTrait: t8) = (Set new)).
	self assert: ((self requiredMethodsForTrait: t9) = (Set new)).
	self assert: ((self requiredMethodsForTrait: t10) = (Set with:#m12)).
