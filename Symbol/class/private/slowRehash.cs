slowRehash		"Symbol slowRehash"
	"Rebuild the hash table, reclaiming unreferenced Symbols."
	| count oldCount |
	SelectorTables _ (1 to: 6) collect: [ :i | (1 to: 26) collect: [ :j | Array new: 0 ] ].
	OtherTable _ (1 to: 51) collect: [:k | Array new: 0].
	oldCount _ Symbol instanceCount.
	count _ 0.
	'Rebuilding Symbol Tables...'
		displayProgressAt: Sensor cursorPoint
		from: 0 to: oldCount
		during:
			[:bar |
			Smalltalk garbageCollect.
			Symbol allInstancesDo:
				[ :sym |
				self intern: sym.
				bar value: (count _ count + 1)]].
	^ (oldCount - count) printString , ' reclaimed'