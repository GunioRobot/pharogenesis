findMethod
	| selectors selection |
	selectors := self theClass selectors asSortedArray.
	selectors isEmpty ifTrue: [^nil].
	selection := OBChoiceRequest labels: selectors.
	selection ifNotNil: [(OBMethodNode 
									on: selection
									inClass: self theClass) signalSelection].