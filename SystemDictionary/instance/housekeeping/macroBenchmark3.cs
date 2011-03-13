macroBenchmark3   "Smalltalk macroBenchmark3"
	| testBlock tallies prev receiver |
	"Runs the stepping simulator with the messageTally tree (like tallySends)."
	testBlock _
		['Running the context step simulator'
			displayProgressAt: Sensor cursorPoint
			from: 0 to: 200
			during:
				[:bar |
				1 to: 200 do:
				[:x | bar value: x.
				Float pi printString.
				15 factorial printString]]].
	tallies _ MessageTally new class: testBlock receiver class
							method: testBlock method.
	receiver _ nil.
	prev _ testBlock.
	thisContext sender
		runSimulated: testBlock
		contextAtEachStep:
			[:current |
			current == prev ifFalse: 
				["call or return"
				prev sender == nil ifFalse: 
					["call only"
					(receiver == nil or: [current receiver == receiver])
						ifTrue: [tallies tally: current by: 1]].
				prev _ current]].
