allSentMessagesWithout: classesAndMessagesPair 
	"Answer the set of selectors which are sent somewhere in the system,  
	computed in the absence of the supplied classes and messages."
	| sent absentClasses absentSelectors |
	sent _ IdentitySet new: CompiledMethod instanceCount.
	absentClasses _ classesAndMessagesPair first.
	absentSelectors _ classesAndMessagesPair second.
	self flag: #shouldBeRewrittenUsingSmalltalkAllClassesDo:.
	"sd 29/04/03"
	Cursor execute
		showWhile: [Smalltalk classNames
				do: [:cName | ((absentClasses includes: cName)
						ifTrue: [{}]
						ifFalse: [{Smalltalk at: cName. (Smalltalk at: cName) class}])
						do: [:cl | (absentSelectors isEmpty
								ifTrue: [cl selectors]
								ifFalse: [cl selectors copyWithoutAll: absentSelectors])
								do: [:sel | "Include all sels, but not if sent by self"
									(cl compiledMethodAt: sel) literals
										do: [:m | 
											(m isSymbol)
												ifTrue: ["might be sent"
													m == sel
														ifFalse: [sent add: m]].
											(m isMemberOf: Array)
												ifTrue: ["might be performed"
													m
														do: [:x | (x isSymbol)
																ifTrue: [x == sel
																		ifFalse: [sent add: x]]]]]]]].
			"The following may be sent without being in any literal frame"
			1
				to: Smalltalk specialSelectorSize
				do: [:index | sent
						add: (Smalltalk specialSelectorAt: index)]].
	Smalltalk presumedSentMessages
		do: [:sel | sent add: sel].
	^ sent