processNameList
	"since processList is a WeakArray, we have to strengthen the result"
	| pw tally |
	pw _ Smalltalk at: #CPUWatcher ifAbsent: [ ].
	tally _ pw ifNotNil: [ pw current ifNotNil: [ pw current tally ] ].
	^ (processList asOrderedCollection
		copyWithout: nil)
		collect: [:each | | percent |
			percent _ tally
				ifNotNil: [ ((((tally occurrencesOf: each) * 100.0 / tally size) roundTo: 1)
						asString padded: #left to: 2 with: $ ), '% '  ]
				ifNil: [ '' ].
			percent, (self prettyNameForProcess: each)
		] 