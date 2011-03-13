doMenuItem: aCollection with: event
	| realTarget selector nArgs |
	selector := aCollection second.
	nArgs := selector numArgs.
	realTarget := aCollection first.
	realTarget == #myWorld ifTrue: [realTarget := myWorld].
	realTarget == #myHand ifTrue: [realTarget := myHand].
	^nArgs = 0 
		ifTrue:[realTarget perform: selector]
		ifFalse:[realTarget perform: selector with: event].
