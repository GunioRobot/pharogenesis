testAtAllPut
	|table|.
	table := Array new: 5.
	table atAllPut: $a.
	self assert: (table allSatisfy: [:elem | elem = $a])