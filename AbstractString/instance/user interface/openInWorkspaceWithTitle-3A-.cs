openInWorkspaceWithTitle: aTitle
	"Open up a workspace with the receiver as its contents, with the given title"

	(Workspace new contents: self) openLabel: aTitle