tocColumnsForMessageID: messageID  atIndex: index
	"return a list of strings to display in columns of the TOC list for a particular message"
	| columns rawColumnsFromDB |
	columns := Array new: 6.

	"first, put the index"
	columns at: 1 put: index printString.

	rawColumnsFromDB _ mailDB getTOCstringAsColumns: messageID.

	columns at: 2 put: ((rawColumnsFromDB at: 5) ifTrue: ['@'] ifFalse: [' ']).
	columns at: 3 put: (rawColumnsFromDB at: 1).
	columns at: 4 put: (rawColumnsFromDB at: 2).
	columns at: 5 put: (rawColumnsFromDB at: 4).
	columns at: 6 put: (rawColumnsFromDB at: 3).

	^columns