isSteppingSelector: aSelector
	"Return true if the receiver is currently stepping in its world"
	| aWorld |
	^ (aWorld _ self world)
		ifNil:		[false]
		ifNotNil:	[aWorld isStepping: self selector: aSelector]