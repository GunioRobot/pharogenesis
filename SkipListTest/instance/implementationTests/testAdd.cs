testAdd
	"tests size after adding element"
	
	"self run:#testAdd"
	| s |
	s := SkipList new.
	s add: 1.
	self assert: s size = 1
