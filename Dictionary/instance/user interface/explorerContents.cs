explorerContents

	| contents |
	
	contents _ OrderedCollection new.
	self keysSortedSafely do: [:key |
		contents add: (ObjectExplorerWrapper
			with: (self at: key)
			name: (key printString contractTo: 32)
			model: self)].
	^contents
