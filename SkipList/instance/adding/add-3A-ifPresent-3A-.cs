add: element ifPresent: aBlock
	| node lvl s |
	node _ self search: element updating: splice.
	node ifNotNil: [aBlock ifNotNil: [^ aBlock value: node]].
	lvl _ self randomLevel.
	node _ SkipListNode on: element level: lvl.
	level + 1 to: lvl do: [:i | splice at: i put: self].
	1 to: lvl do: [:i |
				s _ splice at: i.
				node atForward: i put: (s forward: i).
				s atForward: i put: node].
	numElements _ numElements + 1.
	splice atAllPut: nil.
	^ element