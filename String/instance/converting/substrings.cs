substrings
	"Answer an array of the substrings that compose the receiver."
	| result aStream char |
	result _ WriteStream on: (Array new: 10).
	aStream _ WriteStream on: (String new: 16).
	1 to: self size do: [:i |
		((char _ self at: i) isSeparator)
		 ifTrue: [aStream isEmpty ifFalse: [result nextPut: aStream contents. aStream reset]]
		 ifFalse: [aStream nextPut: char]].
	aStream isEmpty ifFalse: [result nextPut: aStream contents].
	^ result contents