detectShiftedRuns
	| sortedRuns lastY run shiftedRuns |
	runs size < 2 ifTrue: [^ nil].
	shiftedRuns _ OrderedCollection new.
	sortedRuns _ SortedCollection sortBlock: [:a1 :a2 | a1 key x < a2 key x].
	runs associationsDo: [:assoc | sortedRuns add: assoc].
	lastY _ sortedRuns first key y.
	2 to: sortedRuns size do:[:i | 
		run _ sortedRuns at: i.
		run key y > lastY
			ifTrue: [lastY _ run key y]
			ifFalse: [shiftedRuns add: run]].
	^ shiftedRuns