nodeDeleted: announcement 
	"This gets called if an action causes the currently selected node to be deleted."

	self selectedNode = announcement node
		ifTrue: 
			[self getChildren.
			self changed: #list.
			self selection: 0]