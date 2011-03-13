collapse
	"Get the receiver's view to change to a collapsed view on the screen."
	| collapsePoint |
	collapsePoint _ view chooseCollapsePoint.
	view collapse.
	view align: view displayBox topLeft with: collapsePoint.
	view displayEmphasized