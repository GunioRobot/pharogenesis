tallySendsTo: receiver inBlock: aBlock showTree: treeOption
	"MessageTally tallySends: [3.14159 printString]"
	"This method uses the simulator to count the number of calls on each method
	invoked in evaluating aBlock. If receiver is not nil, then only sends
	to that receiver are tallied.
	Results are presented as leaves, sorted by frequency,
	preceded, optionally, by the whole tree."
	| prev tallies startTime totalTime |
	startTime _ Time millisecondClockValue.
	tallies _ MessageTally new class: aBlock receiver class
							method: aBlock method.
	prev _ aBlock.
	thisContext sender
		runSimulated: aBlock
		contextAtEachStep:
			[:current |
			current == prev ifFalse: 
				["call or return"
				prev sender == nil ifFalse: 
					["call only"
					(receiver == nil or: [current receiver == receiver])
						ifTrue: [tallies tally: current by: 1]].
				prev _ current]].

	totalTime _ Time millisecondClockValue - startTime // 1000.0 roundTo: 0.01.
	(StringHolder new contents:
		(String streamContents:
			[:s |
			s nextPutAll: 'This simulation took ' , totalTime printString
							, ' seconds.'; cr.
			treeOption
				ifTrue: [tallies fullPrintOn: s tallyExact: true orThreshold: 0]
				ifFalse: [tallies leavesPrintOn: s tallyExact: true orThreshold: 0].
			tallies close]))
		openLabel: 'Spy Results'