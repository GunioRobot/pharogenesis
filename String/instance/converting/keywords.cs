keywords
	"Answer an array of the keywords that compose the receiver."
	| result aStream char |
	result _ WriteStream on: (Array new: 10).
	aStream _ WriteStream on: (String new: 16).
	1 to: self size do:
		[:i |
		aStream nextPut: (char _ self at: i).
		char = $: ifTrue: 
				[result nextPut: aStream contents.
				aStream reset]].
	aStream isEmpty ifFalse: [result nextPut: aStream contents].
	^ result contents