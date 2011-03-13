listForPattern: pat sortMode: sortMode
	"Make the list be those file names which match the pattern."
	| entries sizePad newList allFiles |
	entries _ self entries.
	sizePad _ (entries inject: 0 into: [:mx :entry | mx max: (entry at: 5)])
					asStringWithCommas size - 1.
	newList _ sortMode == #name  "case-insensitive compare"
		ifTrue: [(SortedCollection new: 30) sortBlock: [:x :y | (x compare: y) <= 2]]
		ifFalse: [(SortedCollection new: 30) sortBlock: [:x :y | (x compare: y) >= 2]].
	allFiles _ pat = '*'.
	entries do:
		[:entry | "<name><creationTime><modificationTime><dirFlag><fileSize>"
		(allFiles or: [pat match: entry first]) ifTrue:
			[newList add: (self fileNameFormattedFrom: entry 
						sizePad: sizePad sortMode: sortMode)]].
	^ newList