analogousCodeTo: aMethodProperties
	| bs |
	(bs := self basicSize) ~= aMethodProperties basicSize ifTrue:
		[^false].
	1 to: bs do:
		[:i|
		((self basicAt: i) analogousCodeTo: (aMethodProperties basicAt: i)) ifFalse:
			[^false]].
	^true