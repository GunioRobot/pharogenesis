selectedItem
	| items |
	items _ self items.
	^ items detect: [:each | each == lastSelection] ifNone: [items first]