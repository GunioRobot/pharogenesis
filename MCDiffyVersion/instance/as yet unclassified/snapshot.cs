snapshot
	^ snapshot ifNil: [snapshot _ MCPatcher apply: patch to: self baseSnapshot]