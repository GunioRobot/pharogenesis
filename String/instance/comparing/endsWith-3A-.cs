endsWith: suffix
	"Answer whether the tail end of the receiver is the same as suffix.
	The comparison is case-sensitive."
	| extra |
	(extra _ self size - suffix size) < 0 ifTrue: [^ false].
	^ (self findSubstring: suffix in: self startingAt: extra + 1
			matchTable: CaseSensitiveOrder) > 0
"
  'Elvis' endsWith: 'vis'
"