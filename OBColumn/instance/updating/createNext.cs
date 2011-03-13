createNext
	| nextMetaNode created |
	nextMetaNode := self nextMetaNode.
	created := nextMetaNode columnInPanel: panel node: self selectedNode.
	panel pushColumn: created.
	^created