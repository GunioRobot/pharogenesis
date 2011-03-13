navigateToRecentMethod
	"Put up a menu of recent selectors visited and navigate to the one chosen"

	| visited aSelector |
	(visited := self selectorsVisited) size > 1 ifTrue:
		[visited := visited copyFrom: 1 to: (visited size min: 20).
		aSelector := (SelectionMenu selections: visited) startUpWithCaption: 'Recent methods visited in this browser'.
		aSelector isEmptyOrNil ifFalse: [self displaySelector: aSelector]]