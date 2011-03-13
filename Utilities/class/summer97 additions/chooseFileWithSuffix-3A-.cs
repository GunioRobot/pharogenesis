chooseFileWithSuffix: aSuffix
	"Utilities chooseFileWithSuffix: '.gif'"
	| aList |
	aList := FileDirectory default fileNamesMatching: '*', aSuffix.
	aList size > 0
		ifTrue:
			[^ UIManager default chooseFrom: aList values: aList title: 'Choose a file' translated]
		ifFalse:
			[self inform: 'Sorry, there are no files
whose names end with' translated, ' "', aSuffix, '".'.
			^ nil]