aboutMethod: aSelector
	"Give the user documentation for the selector"

	| aClass help |
	aClass _ scriptedPlayer class classThatUnderstands: aSelector.
	help _ aClass firstCommentAt: aSelector.
	help ifNotNil:
		[self inform: (help string withNoLineLongerThan: 25)]
