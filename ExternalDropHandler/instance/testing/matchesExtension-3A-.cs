matchesExtension: aExtension
	(self extension isNil or: [aExtension isNil])
		ifTrue: [^false].
	^extension = aExtension