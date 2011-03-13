endsWith: aString
	"Answer whether the tail end of the receiver is the same as aString.  Case-sensitive.  1/26/96 sw"
	| mySize |
	(mySize _ self size) < aString size ifTrue: [^ false].
	^ (self copyFrom: (mySize - aString size + 1) to: mySize) = aString

"  'Elvis' endsWith: 'vis'"