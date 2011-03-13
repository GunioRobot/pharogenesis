testIsMessageSentInCategoryWithTheSelectorInsideAnArray
	5 timesRepeat: [classFactory newClass].
	(classFactory createdClasses asArray first: 3) do: [:class|	
		class compile: 'meth ^#(a b m c)'].
	self assert: (navigator isMessage: #m sentInClassCategory: classFactory defaultCategory).
	self assert: (navigator allSendersOf: #m inClassCategory: classFactory defaultCategory) size = 3