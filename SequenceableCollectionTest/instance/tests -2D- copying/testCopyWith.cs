testCopyWith
	| table |
	table := Array new: 4 withAll: 3.
	self assert: table = #(3 3 3 3).
	table := table copyWith: 4.
	self assert: table = #(3 3 3 3 4).