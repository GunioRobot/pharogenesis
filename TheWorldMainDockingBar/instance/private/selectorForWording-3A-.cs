selectorForWording: aString 
	"Private - Create a valid smalltalk selector from an english  
	wording.  
	'foo' -> #foo  
	'foo....' -> #foo  
	'foo bar' -> #fooBar  
	'foo bar (f)' - #fooBar  
	"
	| words selector temp |
	temp := aString.
	('*(*)*' match: temp)
		ifTrue: [| pre post | 
			pre := temp copyUpTo: $(.
			post := temp copyAfterLast: $).
			temp := pre , post].
	""
	temp := temp
				collect: [:each | ""
					each isLetter
						ifTrue: [each]
						ifFalse: [Character space]].
	words := temp subStrings: Character separators.
	selector := String
				streamContents: [:stream | ""
					words
						do: [:word | stream nextPutAll: word capitalized]].
	selector at: 1 put: selector first asLowercase.
	""
	^ selector asSymbol