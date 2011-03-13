selectedSelector
	"Try to make a selector out of the current text selection.
	6/18/96 sw: incorporated Dan's code for hunting down selectors with keyword parts; while this doesn't give a true parse, and will not handle parentheses correctly, for example, in most cases it does what we want, in where it doesn't, we're none the worse for it."

	| sel |

	sel _  self selection string withBlanksTrimmed.

	(sel includes: $:) ifTrue:
		[sel _ String streamContents:
			[:s | ((sel findTokens: Character separators)
						select: [:tok | tok last = $:])
					do: [:key | s nextPutAll: key]]].

	sel size == 0 ifTrue: [^ nil].
	Symbol hasInterned: sel ifTrue:
		[:aSymbol | ^ aSymbol].

	^ nil