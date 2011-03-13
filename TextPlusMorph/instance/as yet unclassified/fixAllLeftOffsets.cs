fixAllLeftOffsets

	| am |

	text runs withStartStopAndValueDo: [:start :stop :attributes |
		attributes do: [:att |
			(att isMemberOf: TextAnchor) ifTrue: [
				am _ att anchoredMorph.
				(am isNil or: [am world isNil]) ifFalse: [
					am 
						valueOfProperty: #geeMailLeftOffset 
						ifAbsent: [
							am setProperty: #geeMailLeftOffset toValue: am left - self left
						]
				]
			]
		]
	].

