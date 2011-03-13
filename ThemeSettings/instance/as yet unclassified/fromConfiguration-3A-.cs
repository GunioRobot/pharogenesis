fromConfiguration: tree
	"Update the settings from the given tree."
	
	(tree at: #windowColor ifAbsent: []) ifNotNilDo: [:v | self windowColor: v].
	(tree at: #autoSelectionColor ifAbsent: []) ifNotNilDo: [:v | self autoSelectionColor: v].
	(tree at: #selectionColor ifAbsent: []) ifNotNilDo: [:v | self selectionColor: v]