clause: aClause
	| min |
	super clause: aClause.

	self rule2.

	clause wordsDo: [ :eachWord |
		eachWord events do: [ :each |
			min _ self lowerDurationAt: each phoneme.
			eachWord isAccented ifFalse: [min _ min / 2.0].
			each duration: each duration + min / 1.4 / self speed]].
	clause syllablesDo: [ :each | each events recomputeTimes]