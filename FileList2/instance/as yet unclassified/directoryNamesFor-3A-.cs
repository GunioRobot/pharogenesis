directoryNamesFor: fullString
	| entries |
	entries _ (FileDirectory on: fullString) directoryNames.
	dirSelectionBlock ifNotNil:[entries _ entries select: dirSelectionBlock].
	^entries