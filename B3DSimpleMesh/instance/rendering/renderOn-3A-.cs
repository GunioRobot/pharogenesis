renderOn: aRenderer
	| box bounds |
	box _ nil.
	1 to: self size do:[:i|
		bounds _ (self at: i) renderOn: aRenderer.
		box == nil ifTrue:[box _ bounds] ifFalse:[box _ box quickMerge: bounds].
	].
	^box