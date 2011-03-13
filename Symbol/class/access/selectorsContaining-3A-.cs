selectorsContaining: aString
	"Answer a list of selectors that contain aString within them. Case-insensitive"

	| size selectorList ascii |

	selectorList _ OrderedCollection new.
	(size _ aString size) = 0 ifTrue: [^selectorList].

	aString size = 1 ifTrue:
		[
			ascii _ aString first asciiValue.
			ascii < 128 ifTrue: [selectorList add: (SymbolTable like: aString)]
		].

	aString first isLetter ifFalse:
		[
			aString size == 2 ifTrue: 
				[Symbol hasInterned: aString ifTrue:
					[:s | selectorList add: s]].
			^selectorList
		].

	selectorList _ selectorList copyFrom: 2 to: selectorList size.

	SymbolTable do:
		[:each |
			each size >= size ifTrue:
				[
					((each at: 1) isLowercase and:
						[((each findString: aString startingAt: 1 caseSensitive: false) > 0)])
							ifTrue: [selectorList add: each]
				]
		].

	^selectorList

"Symbol selectorsContaining: 'scon'"