selectorsContaining: aString
	"Answer a list of selectors that contain aString within them.  Case-insensitive."
	| size table candidate selectorList selectorTable ascii |

	selectorList _ OrderedCollection new.
	(size _ aString size) = 0 ifTrue: [^ selectorList].

	aString size = 1 ifTrue:
		[ascii _ aString first asciiValue.
		ascii < 128 ifTrue:
			[selectorList add: (SingleCharSymbols at: ascii + 1)]].
	aString first isLetter ifFalse: [
		aString size == 2 ifTrue: 
			[Symbol hasInterned: aString ifTrue: [:s | selectorList add: s]].
		^ selectorList].
	(SelectorTables size to: 1 by: -1) do:
		[:j | selectorTable _ SelectorTables at: j.
		1 to: 26 do: [:index |
		table _ selectorTable at: index.
		1 to: table size do: 
			[:t | 
			((candidate _ table at: t) == nil) ifFalse:
				[candidate size >= size ifTrue:
					[((candidate findString: aString startingAt: 1 caseSensitive: false) > 0) ifTrue:
							[selectorList add: candidate]]]]]].
	^ selectorList

"Symbol selectorsContaining: 'scon' "