flattenDownAllTraits
	self traitComposition allTraits do: [:each | self flattenDown: each].
	self assert: [ self traitComposition isEmpty ].
	self traitComposition: nil.