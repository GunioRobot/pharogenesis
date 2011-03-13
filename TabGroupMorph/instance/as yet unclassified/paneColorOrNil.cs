paneColorOrNil
	"Answer the window's pane color or nil otherwise."

	^super paneColorOrNil ifNotNilDo: [:c | self theme subgroupColorFrom: c]