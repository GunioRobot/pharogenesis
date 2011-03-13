testSingleClassCreation
	|class elementsInCategoryForTest |
	class := factory 
		newSubclassOf: Object 
		instanceVariableNames: 'a b c' 
		classVariableNames: 'X Y'.
	self assert: (SystemNavigation new allClasses includes: class).
	elementsInCategoryForTest := SystemOrganization listAtCategoryNamed: factory defaultCategory. 
	self assert: elementsInCategoryForTest = {class name}.
	self assert: class instVarNames = #(a b c).
	self assert: class classPool keys = #(X Y) asSet