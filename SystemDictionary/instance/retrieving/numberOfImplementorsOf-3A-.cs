numberOfImplementorsOf: aSelector  
	"Answer a count of the implementors of the given selector found in the system"

	| aCount |
	aCount _ 0.
	self allBehaviorsDo:
		[:class |
			(class includesSelector: aSelector)
				ifTrue: [aCount _ aCount + 1]].
	^ aCount
"
Smalltalk numberOfImplementorsOf: #contents.
Smalltalk numberOfImplementorsOf: #nobodyImplementsThis. 
Smalltalk numberOfimplementorsOf: #numberOfImplementorsOf:.
"