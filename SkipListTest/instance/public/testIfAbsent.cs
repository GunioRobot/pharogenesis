testIfAbsent
	"self run: #testIfAbsent"
	"self debug: #testIfAbsent"

	| sk temp |
	sk := SkipList new.
	sk at: 11 put: '111111'.
	sk at: 3 put: '3333'.
	sk at: 7 put: '77777'.
	sk add: 7 ifPresent: [sk at: 8 put: '88'].
	temp := sk at: 9 ifAbsent: [sk at: 8].
	self assert: (temp = '88')
	
	

	