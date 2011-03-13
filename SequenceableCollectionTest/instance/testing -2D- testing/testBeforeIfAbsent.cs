testBeforeIfAbsent

	| col |
	col := #(2 3 4).	
	self assert: ((col before: 2 ifAbsent: ['block']) = 'block').
	self assert: ((col before: 5 ifAbsent: ['block']) = 'block').
	self assert: ((col before: 3 ifAbsent: ['block']) = 2).