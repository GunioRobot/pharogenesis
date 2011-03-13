beginsWith: prefix
	"Answer whether the receiver begins with the given prefix string.
	The comparison is case-sensitive."
	| prefixSize |
	prefixSize _ prefix size.
	self size < prefixSize ifTrue: [^ false].
	1 to: prefixSize do:
		[:index | (self at: index) = (prefix at: index) ifFalse: [^ false]].
	^ true