searchFor: aString
	| hitlines response |
	hitlines _ pages select: [:each | each text includesSubstring: aString caseSensitive: false].
	hitlines isEmpty
	ifTrue: [^aString, ' not found']
	ifFalse: [
		response _ WriteStream on: String new.
		response nextPutAll: '<h2>Search results for ',aString,'</h2><ul>'.
		hitlines do: [:each
			|response nextPutAll: '<li>',(self pageURL: each),'...',(each address)].
		response nextPutAll: '</ul>'.
		^response contents].
