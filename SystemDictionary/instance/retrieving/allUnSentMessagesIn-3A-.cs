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
					[:m |
					(m isMemberOf: Symbol)  "might be sent"
						ifTrue: [all remove: m ifAbsent: []].
					(m isMemberOf: Array)  "might be performed"
						ifTrue: [m do: [:x | all remove: x ifAbsent: []]].
					]]].
		"The following may be sent without being in any literal frame"
		1 to: self specialSelectorSize do: 
			[:index | 
			all remove: (self specialSelectorAt: index) ifAbsent: []]].
	^ all