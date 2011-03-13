allUnSentMessagesIn: aList
	"Answer the subset of aList (a selector list) which are not sent anywhere in the system.  Factored out from#allUnSentMessages 5/8/96 sw"

	|  anArray all |
	all _ aList copy.
	anArray _ Array new: 0.
	Cursor execute
		showWhile: 
			[self allBehaviorsDo: 
				[:cl |
				 cl selectorsDo: 
					[:sel | 
					(cl compiledMethodAt: sel) literals do: 
						[:m |
						(m isMemberOf: Symbol)  "might be sent"
							ifTrue: [all remove: m ifAbsent: []].
						(m isMemberOf: Array)  "might be performed"
							ifTrue: [m do: [:x | all remove: x ifAbsent: []]].
						]]].
			1 to: self specialSelectorSize do: 
				[:index | 
				all remove: (self specialSelectorAt: index) ifAbsent: []]].
	^ all