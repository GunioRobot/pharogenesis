refusesToAcceptCode
	"Answer whether receiver, given its current contentsSymbol, could accept code happily if asked to"

	^ (#(byteCodes documentation altSyntax tiles) includes: self contentsSymbol)