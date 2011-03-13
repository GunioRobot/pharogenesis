viewChanges
	"Note that the patchLabel will be parsed in MCPatchBrowser>>installSelection, so don't translate it!"
	| patch patchLabel |
	patchLabel := 'changes between {1} and {2}' format: { self selectedInfo name. ancestry name }.
	patch := self baseSnapshot patchRelativeToBase: self selectedSnapshot.
	(MCPatchBrowser forPatch: patch) label: patchLabel; show