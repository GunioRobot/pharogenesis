collapseColumns: columnsToCollapse

	| columnsToRemove |
	columnsToRemove _ OrderedCollection new.
	columnsToCollapse do:
		[:c |
		rows - 1 to: 0 by: -1 do: [:r | self collapseColumn: c fromRow: r].
		(self tileAt: c@(rows-1)) disabled ifTrue: [columnsToRemove add: c]].
	self world displayWorld.
	columnsToRemove reverseDo: [:c | self removeColumn: c].
