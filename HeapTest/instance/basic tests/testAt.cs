testAt
	"self run: #testAt" 

	| heap |
	heap := Heap new.
	heap add: 3.
	self assert: (heap at: 1) = 3.
	self should: [heap at: 2] raise: Error.
	heap add: 4.
	self assert: (heap at: 1) = 3.
	self assert: (heap at: 2) = 4.

	