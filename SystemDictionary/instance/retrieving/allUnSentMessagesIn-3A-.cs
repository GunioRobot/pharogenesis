allUnSentMessagesIn: selectorSet
	"Answer the subset of selectorSet which are not sent anywhere in the system.
	Factored out from#allUnSentMessages "
	|  all |
	all _ selectorSet copy.
	Cursor execute showWhile: 
		[self allBehaviorsDo: 
			[:cl | cl selectorsDo: 
				[:sel | 
				(cl compiledMethodAt: sel) literals do: 
					[:lit |
					(lit isMemberOf: Symbol)  "might be sent"
						ifTrue: [all remove: lit ifAbsent: []].
					(lit isMemberOf: Array)  "might be performed"
						ifTrue: [lit do:
								[:elt |
								(elt isMemberOf: Array)
									ifTrue: [elt do: [:e | all remove: e ifAbsent: []]]
									ifFalse: [all remove: elt ifAbsent: []]]].
					]]].
		"The following may be sent without being in any literal frame"
		1 to: self specialSelectorSize do: 
			[:index | 
			all remove: (self specialSelectorAt: index) ifAbsent: []]].
	^ all