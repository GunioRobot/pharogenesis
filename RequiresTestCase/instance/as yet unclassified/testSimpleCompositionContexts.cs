testSimpleCompositionContexts
	self assert: (self requiredMethodsOfTrait: t7 inContextOf: t8) = (Set new).
	self assert: (self requiredMethodsOfTrait: t9 inContextOf: t10) = (Set with: #m12).
	self assert: (self requiredMethodsOfTrait: t9 inContextOf: t11) = (Set with: #m12).