trashTitle
	| label pgs |
	label _ 'T R A S H'.
	^ (pgs _ ScrapsBook pages size) < 2
		ifTrue:
			[label]
		ifFalse:
			[label, '  (', pgs printString, ' pages)']