serviceViewContentsInWorkspace
	"Answer a service for viewing the contents of a file in a workspace"
	
	^ (SimpleServiceEntry provider: self label: 'workspace with contents' selector: #viewContentsInWorkspace)
			description: 'open a new Workspace whose contents are set to the contents of this file'