selectorsContaining: aString
	"Answer a list of selectors that contain aString within them.  Case-insensitive.
	 1/15/96 sw.  This is an extremely slow, sledge-hammer approach at present, taking around 30 seconds to execute on an FX.  A variety of speedups is conceivable -- improvements invited."

	| key size table candidate selectorList selectorTable |

	key _ aString asLowercase.

	selectorList _ OrderedCollection new.
	size _ key size.

	(SelectorTables size to: 1 by: -1) do:
		[:j | selectorTable _ SelectorTables at: j.
		1 to: 26 do: [:index |
		table _ selectorTable at: index.
		1 to: table size do: 
			[:t | 
			((candidate _ table at: t) == nil) ifFalse:
				[candidate size >= size ifTrue:
					[((candidate asLowercase findString: key startingAt: 1) > 0)
						ifTrue:
							[selectorList add: candidate]]]]]].
	^ selectorList


"Symbol selectorsContaining: 'scon' OrderedCollection (includesController: selectorsContaining: codeThisContext conversionNotesContents isControlWanted isControlActive isConstantNumber isConnectionSet thisContext )"