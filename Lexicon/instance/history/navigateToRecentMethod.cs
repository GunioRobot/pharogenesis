navigateToRecentMethod
	"Put up a menu of recent selectors visited and navigate to the one chosen"

	| visited aSelector |
	(visited _ self selectorsVisited) size > 1 ifTrue:
		[visited _ visited copyFrom: 1 to: (visited size min: 20).
		aSelector _ (SelectionMenu selections: visited) startUpWithCaption: 'Recent methods visited in this browser'.
		aSelector isEmptyOrNil ifFalse: [self displaySelector: aSelector]]