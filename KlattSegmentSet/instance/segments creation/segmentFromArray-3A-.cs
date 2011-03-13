segmentFromArray: anArray
	| answer |
	answer := KlattSegment new.
	#(name: rank: duration: features:)
		doWithIndex: [ :each :index | answer perform: each with: (anArray at: index)].
	5 to: anArray size do: [ :each | answer addParameter: (self parameterFromArray: (anArray at: each))].
	^ answer