tocColumnsForRow: row
	"return a list of strings, one list for each column in the TOC, for the specified row in the TOC"

	^self tocColumnsForMessageID: (currentMessages at: row) atIndex: row

