viewChanges
	"Note that the patchLabel will be parsed in MCPatchBrowser>>installSelection, so don't translate it!"
	
	self viewChanges: (self baseSnapshot patchRelativeToBase: self selectedSnapshot)
	