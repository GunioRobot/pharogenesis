chooseFileWithSuffix: aSuffix
	"Utilities chooseFileWithSuffix: '.gif'"
	| aList aName |
	aList _ FileDirectory default fileNamesMatching: '*', aSuffix.
	aList size > 0
		ifTrue:
			[aName _ (SelectionMenu selections: aList) startUpWithCaption: 'Choose a file'.
			^ aName]
		ifFalse:
			[self inform: 'Sorry, there are no files
whose names end with "', aSuffix, '".'.
			^ nil]