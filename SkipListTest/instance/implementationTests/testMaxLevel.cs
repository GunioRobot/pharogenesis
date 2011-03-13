testMaxLevel
	"No node should have a level greater than the skiplist maxLevel"
	"self run: #testMaxLevel"
	| s |
	s := SkipList new.
	s add: 12.
	s add: 53.
	s add: 14.
	s
		nodesDo: [:n | 
			      self
   					assert: n level <= s maxLevel]