testRandomLevel
	"a randomLevel should not be greater than maxLevel"
	"self run: #testRandomLevel"
	| s |
	s := SkipList new.
	s maxLevel: 5.
	self assert: s randomLevel <= 5