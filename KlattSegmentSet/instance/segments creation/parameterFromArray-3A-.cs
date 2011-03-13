parameterFromArray: anArray
	| answer |
	answer := KlattSegmentParameter new.
	#(selector: steady: fixed: proportion: external: internal:)
		doWithIndex: [ :each :index | answer perform: each with: (anArray at: index)].
	^ answer