testAt
	"self debug: #testAt"
	| array |
	array := RunArray new: 5 withAll: 2.
	self assert: (array at: 3) = 2.
	
	array at: 3 put: 5.
	self assert: (array at: 3) = 5
