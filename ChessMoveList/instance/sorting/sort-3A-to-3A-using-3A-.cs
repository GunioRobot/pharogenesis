sort: i to: j using: sorter
	"Sort elements i through j of self to be nondescending according to sorter."

	| di dij dj tt ij k l n |
	"The prefix d means the data at that index."
	(n _ j + 1  - i) <= 1 ifTrue: [^self].	"Nothing to sort." 
	 "Sort di,dj."
	di _ collection at: i.
	dj _ collection at: j.
	(sorter sorts: di before: dj) ifFalse:["i.e., should di precede dj?"
		collection swap: i with: j.
		tt _ di. di _ dj. dj _ tt].
	n > 2 ifTrue:["More than two elements."
		ij _ (i + j) // 2.  "ij is the midpoint of i and j."
		 dij _ collection at: ij.  "Sort di,dij,dj.  Make dij be their median."
		 (sorter sorts: di before: dij) ifTrue:["i.e. should di precede dij?"
			(sorter sorts: dij before: dj) "i.e., should dij precede dj?"
				ifFalse:[collection swap: j with: ij.
					 	dij _ dj].
		] ifFalse:[  "i.e. di should come after dij"
			collection swap: i with: ij.
			 dij _ di
		].
		n > 3 ifTrue:["More than three elements."
			"Find k>i and l<j such that dk,dij,dl are in reverse order.
			Swap k and l.  Repeat this procedure until k and l pass each other."
			 k _ i.  l _ j.
			[
				[l _ l - 1.  k <= l and: [sorter sorts: dij before: (collection at: l)]]
					whileTrue.  "i.e. while dl succeeds dij"
				[k _ k + 1.  k <= l and: [sorter sorts: (collection at: k) before: dij]]
					whileTrue.  "i.e. while dij succeeds dk"
				k <= l
			] whileTrue:[collection swap: k with: l]. 
			"Now l<k (either 1 or 2 less), and di through dl are all less than 
			or equal to dk through dj.  Sort those two segments."
			self sort: i to: l using: sorter.
			self sort: k to: j using: sorter]].
