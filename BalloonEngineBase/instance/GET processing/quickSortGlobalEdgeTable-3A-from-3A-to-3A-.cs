quickSortGlobalEdgeTable: array from: i to: j 
	"Sort elements i through j of self to be nondescending according to
	sortBlock."
	"Note: The original loop has been heavily re-written for C translation"
	| di dij dj tt ij k l n tmp again before |
	self var: #array declareC:'int *array'.
	self inline: false.
	"The prefix d means the data at that index."
	(n _ j + 1  - i) <= 1 ifTrue: [^0].	"Nothing to sort." 
	 "Sort di,dj."
	di _ array at: i.
	dj _ array at: j.
	before _ self getSorts: di before: dj. "i.e., should di precede dj?"
	before ifFalse:[
		tmp _ array at: i.
		array at: i put: (array at: j).
		array at: j put: tmp.
		tt _ di.	di _ dj.	dj _ tt].
	n <= 2 ifTrue:[^0].

	"More than two elements."
	ij _ (i + j) // 2.  "ij is the midpoint of i and j."
	dij _ array at: ij.  "Sort di,dij,dj.  Make dij be their median."
	before _ (self getSorts: di before: dij). "i.e. should di precede dij?"
	before ifTrue:[
		before _ (self getSorts: dij before: dj). "i.e., should dij precede dj?"
		before ifFalse:["i.e., should dij precede dj?"
			tmp _ array at: j.
			array at: j put: (array at: ij).
			array at: ij put: tmp.
			dij _ dj]
	] ifFalse:[  "i.e. di should come after dij"
		tmp _ array at: i.
		array at: i put: (array at: ij).
		array at: ij put: tmp.
		 dij _ di].
	n <= 3 ifTrue:[^0].

	 "More than three elements."
	"Find k>i and l<j such that dk,dij,dl are in reverse order.
	Swap k and l.  Repeat this procedure until k and l pass each other."
	k _ i.
	l _ j.

	again _ true.
	[again] whileTrue:[
		before _ true.
		[before] whileTrue:[
			k <= (l _ l - 1)
				ifTrue:[	tmp _ array at: l.
						before _ self getSorts: dij before: tmp]
				ifFalse:[before _ false].
		].
		before _ true.
		[before] whileTrue:[
			(k _ k + 1) <= l
				ifTrue:[	tmp _ array at: k.
						before _ self getSorts: tmp before: dij]
				ifFalse:[before _ false]].

		again _ k <= l.
		again ifTrue:[
			tmp _ array at: k.
			array at: k put: (array at: l).
			array at: l put: tmp]].

	"Now l<k (either 1 or 2 less), and di through dl are all less than or equal to dk
	through dj.  Sort those two segments."
	self quickSortGlobalEdgeTable: array from: i to: l.
	self quickSortGlobalEdgeTable: array from: k to: j.