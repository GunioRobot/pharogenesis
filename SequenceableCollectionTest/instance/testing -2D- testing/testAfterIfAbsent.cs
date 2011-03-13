testAfterIfAbsent

	| col |
	col := #(2 3 4).
	self assert: ((col after: 4 ifAbsent: ['block']) = 'block').
	self assert: ((col after: 5 ifAbsent: ['block']) = 'block').
	self assert: ((col after: 2 ifAbsent: ['block']) = 3).