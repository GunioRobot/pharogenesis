asInteger 
	"Answer the Integer created by interpreting the receiver as the string representation of an integer.  Answer nil if no digits, else find the first digit and then all consecutive digits after that"

	| startPosition tail endPosition |
	startPosition _ self findFirst: [:ch | ch isDigit].
	startPosition == 0 ifTrue: [^ nil].
	tail _ self copyFrom: startPosition to: self size.
	endPosition _ tail findFirst: [:ch | ch isDigit not].
	endPosition == 0 ifTrue: [endPosition _ tail size + 1].
	^ Number readFromString: (tail copyFrom: 1 to: endPosition - 1)

"
'1796exportFixes-tkMX' asInteger
'1848recentLogFile-sw'  asInteger
'donald' asInteger
'abc234def567' asInteger
"