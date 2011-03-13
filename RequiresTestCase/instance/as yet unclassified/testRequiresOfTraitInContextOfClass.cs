testRequiresOfTraitInContextOfClass
	"a class providing nothing, leaves the requirements of the trait intact"
	self assert: (self requiredMethodsOfTrait: t7 inContextOf: c9) = (Set with: #m12).
	"a class can provide the Trait requirement"
	self assert: (self requiredMethodsOfTrait: t7 inContextOf: c10) = (Set new).
	"a class' superclass can provide the Trait requirement"
	self assert: (self requiredMethodsOfTrait: t7 inContextOf: c12) = (Set new).
