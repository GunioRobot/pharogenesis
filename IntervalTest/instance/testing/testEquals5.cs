testEquals5

	self assert: (3 to: 5 by: 2) = (Heap withAll: #(3 5)).
	self deny: (3 to: 5 by: 2) = (Heap withAll: #(3 4 5)).
	self deny: (3 to: 5 by: 2) = Heap new.

	self assert: (Heap withAll: #(3 5)) = (3 to: 5 by: 2).
	self deny: (Heap withAll: #(3 4 5)) = (3 to: 5 by: 2).
	self deny: Heap new = (3 to: 5 by: 2).