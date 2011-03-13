testAddIfPresent
	"adds an already existing element. Decides to add another one in the
	ifPresent block"
	
	| s |
	s := SkipList new.
	s add: 1.
	self
		shouldnt: [s
					add: 1
					ifPresent: [s add: 2]]
		raise: Exception.
	self assert: s size = 2
