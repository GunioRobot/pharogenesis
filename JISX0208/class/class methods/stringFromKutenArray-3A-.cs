stringFromKutenArray: anArray

	| s |
	s _ MultiString new: anArray size.
	1 to: anArray size do: [:i |
		s at: i put: (self charAtKuten: (anArray at: i)).
	].
	^s.
