testIsEqualTo
	"self run: #testIsEqualTo"
	"self debug: #testIsEqualTo"

	| sk sk2 |
	sk := SkipList new.
	sk2 := SkipList new.
	sk at: 11 put: '111111'.
	sk at: 3 put: '3333'.
	sk at: 7 put: '77777'.
	sk at: 9 put: '3333'.
	
	sk2 at: 3 put: '3333'.
	sk2 at: 5 put: '3333'.
	self assert: (sk is: (sk at: 3) equalTo: (sk at: 9)).
	self assert: (sk is: (sk at: 3) equalTo: (sk2 at: 3)).
	self assert: (sk is: (sk at: 3) equalTo: (sk2 at: 5))
	
	
	

	