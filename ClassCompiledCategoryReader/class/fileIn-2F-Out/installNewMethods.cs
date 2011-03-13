installNewMethods

	| clsCatSelMth class category selector method |
	NewMethods do: 
		[:clsCatSelMth |
		class _ clsCatSelMth at: 1.
		category _ clsCatSelMth at: 2.
		selector _ clsCatSelMth at: 3.
		method _ clsCatSelMth at: 4.
		(methodDict includesKey: selector)
			ifTrue: [Smalltalk changes changeSelector: selector class: class]
			ifFalse: [Smalltalk changes addSelector: selector class: class].
		class organization classify: selector under: category.
		class addSelector: selector withMethod: method].
	self initialize