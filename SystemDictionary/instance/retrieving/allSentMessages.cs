allSentMessages
	"Answer the set of selectors which are sent somewhere in the system."
	| sent |
	sent _ IdentitySet new: CompiledMethod instanceCount.
	Cursor execute showWhile: 
		[self allBehaviorsDo: 
			[:cl | cl selectorsDo: 
				[:sel | "Include all sels, but not if sent by self"
			(cl compiledMethodAt: sel) literals do: 
				[:m | 
				(m isMemberOf: Symbol) ifTrue:  "might be sent"
					[m == sel ifFalse: [sent add: m]].
				(m isMemberOf: Array) ifTrue:  "might be performed"
					[m do: [:x | (x isMemberOf: Symbol) ifTrue:
						[x == sel ifFalse: [sent add: x]]]]]]].
		"The following may be sent without being in any literal frame"
		1 to: self specialSelectorSize do: 
			[:index | 
			sent add: (self specialSelectorAt: index)]].
	^ sent