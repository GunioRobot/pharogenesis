directoryContentsFor: pathName
	"FileDirectory directoryContentsFor: ''"

	| entries index done entry |
	entries _ OrderedCollection new: 200.
	index _ 1.
	done _ false.
	[done] whileFalse: [
		entry _ self lookupEntryIn: pathName index: index.
		entry == nil
			ifTrue: [ done _ true ]
			ifFalse: [ entries addLast: entry ].
		index _ index + 1.
	].
	^ entries asArray