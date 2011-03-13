quickRehashAllSets  "Set rehashAllSets"
	| insts |
	self withAllSubclassesDo:
		[:c |
			insts _ c allInstances.
			(insts isEmpty or: [c = MethodDictionary]) ifFalse:
			['Rehashing instances of ' , c name
				displayProgressAt: Sensor cursorPoint
				from: 1 to: insts size
				during: [:bar | 1 to: insts size do: [:x | bar value: x. (insts at: x) rehash]]
			]
		]