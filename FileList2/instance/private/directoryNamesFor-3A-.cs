directoryNamesFor: item
	"item may be file directory or server directory"
	| entries |
	entries _ item directoryNames.
	dirSelectionBlock ifNotNil:[entries _ entries select: dirSelectionBlock].
	^entries