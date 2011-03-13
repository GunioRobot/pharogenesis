prefixEqual: prefix | prefixSize |
	"Answer whether the receiver begins with the given prefix string."

	prefixSize _ prefix size.

	self size < prefixSize ifTrue: [^false].
	1 to: prefixSize do:
		[:index | (self at: index) = (prefix at: index) ifFalse: [^false]].
	^true