pointersTo: anObject do: aBlock 
	"Evaluate the argument aBlock for each pointer to anObject in the 
	system."
	| class obj method i fixedSize |
	Smalltalk allBehaviorsDo: 
		[:class |
		class isBits ifTrue:
			[class == CompiledMethod ifTrue: 
				[class allInstancesDo: 
					[:method | 
					(method pointsTo: anObject)
						ifTrue: [aBlock value: method]]]]
		ifFalse: 
			[class allInstancesDo: 
					[:obj | 
					(obj pointsTo: anObject)
						ifTrue: [(obj == thisContext
								or: ["Could miss something here"
									obj isMemberOf: BlockContext])
								ifFalse: [aBlock value: obj]]]]]