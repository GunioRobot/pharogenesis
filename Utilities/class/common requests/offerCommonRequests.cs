offerCommonRequests
	"Offer up the common-requests menu.  If the user chooses one, then evaluate it, and -- provided the value is a number or string -- show it in the Transcript."

	"Utilities offerCommonRequests"

	| reply result aMenu index normalItemCount strings |

	(CommonRequestStrings == nil or: [CommonRequestStrings isKindOf: Array])
		ifTrue:
			[self initializeCommonRequestStrings].
	strings _ CommonRequestStrings contents.
	normalItemCount _ strings asString lineCount.
	aMenu _ PopUpMenu labels: (strings asString, '
edit this menu') lines: (Array with: normalItemCount).

	index _ aMenu startUp.
	index == 0 ifTrue: [^ self].
	reply _ aMenu labelString lineNumber: index.
	reply size == 0 ifTrue: [^ self].
	index > normalItemCount ifTrue:
		[^ self editCommonRequestStrings].

	result _ self evaluate: reply in: nil to: nil.
	(result isKindOf: Number) | (result isKindOf: String)
		ifTrue:
			[Transcript cr; nextPutAll: result printString]