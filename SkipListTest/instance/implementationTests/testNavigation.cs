testNavigation
	"self run: #testNavigation"
	| node1 node2 node3 node4 skip |
	node1 := SkipListNode
				key: 1
				value: 3
				level: 1.
	node2 := SkipListNode
				key: 2
				value: 7
				level: 2.
	node3 := SkipListNode
				key: 3
				value: 11
				level: 1.
	node4 := SkipListNode
				key: 4
				value: 23
				level: 2.
	node1 atForward: 1 put: node2.
	node2 atForward: 1 put: node3.
	node2 atForward: 2 put: node4.
	node4 atForward: 1 put: nil.
	skip := SkipList new.
	skip atForward: 1 put: node1.
	skip atForward: 2 put: node2.
	self assert: skip first = node1.
	self
		assert: (skip at: 2) = node2 value