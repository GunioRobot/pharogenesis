requestor
	^ self browser requestor node: (self selectedNode ifNil: [self parent])