trashTitle
	| label pgs |
	label _ 'T R A S H' translated.
	^ (pgs _ ScrapsBook pages size) < 2
		ifTrue:
			[label]
		ifFalse:
			[label, ('  ({1} pages)' translated format:{pgs})]
