isSelector: selector providedIn: aClass
	^(self haveInterestsIn: aClass) 
		ifFalse: [aClass classAndMethodFor: selector do: [:c :m | m isProvided] ifAbsent: [false]]
		ifTrue: [(self for: aClass) includes: selector]
		