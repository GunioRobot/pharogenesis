endsWith: suffix
	"Answer whether the tail end of the receiver is the same as suffix.
	The comparison is case-sensitive."
	
	| extra |
	(extra := self size - suffix size) < 0 ifTrue: [^ false].
	^ (self findString: suffix startingAt: extra + 1) > 0
"
  'Elvis' endsWith: 'vis'
"