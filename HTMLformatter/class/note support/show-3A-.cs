show: aCollection
	"Return an HTML list to reference an ordered collection of text. Used in Chat application"
	| ret |
	ret _ WriteStream on: String new.
	ret nextPutAll: '<ul>' ; cr.
	1 to: aCollection size do: [:each |
		ret nextPutAll: '<li>'.
		ret nextPutAll: (aCollection at: each).].
	ret nextPutAll: '</ul>'.
	^ret contents
