endsWith: suffix
	"Answer whether the tail end of the receiver is the same as suffix.
	The comparison is case-sensitive."
	| mySize |
	(mySize _ self size) < suffix size ifTrue: [^ false].
	^ (self copyFrom: (mySize - suffix size + 1) to: mySize) = suffix

"  'Elvis' endsWith: 'vis'"