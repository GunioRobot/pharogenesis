testConsistentSorting
	| definitions shuffledAndSorted|
	definitions _
		{self methodNamed: #a class: #A meta: false.
		self methodNamed: #a class: #A meta: true.
		self methodNamed: #a class: #B meta: false.
		self methodNamed: #b class: #A meta: false.
		self methodNamed: #b class: #B meta: false.
		self classNamed: #A.
		self classNamed: #B}.
	shuffledAndSorted _
		(1 to: 100) collect: [:ea | self sortDefinitions: definitions shuffled].
	self assert: shuffledAndSorted asSet size = 1.