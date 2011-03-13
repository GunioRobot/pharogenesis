allClassesWithUnimplementedCalls
	"Answer an Array of classes that have messages with calls to methods that aren't implemented
	anywhere in the system"
	| all meth dict |
	dict := Dictionary new.
	all := self systemNavigation allImplementedMessages.
	self systemNavigation allBehaviorsDo: [:cl | 
		cl selectorsDo: [:sel | 
			meth := cl compiledMethodAt: sel.
			meth primitive = 0 ifTrue: [
				meth messages do: [:m | 
					(all includes: m) ifFalse: [
						((dict at: cl ifAbsentPut: [ Dictionary new ])
							at: sel ifAbsentPut: [ OrderedCollection new])
								add: m
					]
				]
			]
		]
	].
	^ dict