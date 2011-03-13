listForPattern: pat sortMode: sortMode
	"Make the list be those file names which match the pattern.  SortMode of #name ONLY for now."
	| entries newList allFiles |

	entries _ self entries.
	newList _ true "sortMode == #name"  "case-insensitive compare"
		ifTrue: [(SortedCollection new: 30) sortBlock: [:x :y | (x compare: y) <= 2]]
		ifFalse: [(SortedCollection new: 30) sortBlock: [:x :y | (x compare: y) >= 2]].
	allFiles _ pat = '*'.
	entries do:
		[:entry | "<name>"
		(allFiles or: [pat match: entry]) ifTrue:
			[newList add: (self fileNameFormattedFrom: entry 
						sizePad: 8 sortMode: sortMode)]].
	^ newList