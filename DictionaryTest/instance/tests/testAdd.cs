testAdd
	
	| dict |
	dict := Dictionary new.
	dict add: #a -> 1.
	dict add: #b -> 2.
	self assert: (dict at: #a) = 1.
	self assert: (dict at: #b) = 2