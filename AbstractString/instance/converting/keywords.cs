keywords
	"Answer an array of the keywords that compose the receiver."
	| kwd char keywords |
	keywords _ Array streamContents:
		[:kwds | kwd _ WriteStream on: (String new: 16).
		1 to: self size do:
			[:i |
			kwd nextPut: (char _ self at: i).
			char = $: ifTrue: 
					[kwds nextPut: kwd contents.
					kwd reset]].
		kwd isEmpty ifFalse: [kwds nextPut: kwd contents]].
	(keywords size >= 1 and: [(keywords at: 1) = ':']) ifTrue:
		["Has an initial keyword, as in #:if:then:else:"
		keywords _ keywords allButFirst].
	(keywords size >= 2 and: [(keywords at: keywords size - 1) = ':']) ifTrue:
		["Has a final keyword, as in #nextPut::andCR"
		keywords _ keywords copyReplaceFrom: keywords size - 1
								to: keywords size with: {':' , keywords last}].
	^ keywords