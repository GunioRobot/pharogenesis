doMenuItem: aCollection with: event
	| realTarget selector nArgs |
	selector _ aCollection second.
	nArgs _ selector numArgs.
	realTarget _ aCollection first.
	realTarget == #myWorld ifTrue: [realTarget _ myWorld].
	realTarget == #myHand ifTrue: [realTarget _ myHand].
	realTarget == #myProject ifTrue: [realTarget _ self projectForMyWorld].
	^nArgs = 0 
		ifTrue:[realTarget perform: selector]
		ifFalse:[realTarget perform: selector with: event].
