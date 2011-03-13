actionsForNode: aNode
	^ Array
		with: (OBAction
				label: 'remove'
				receiver: self
				selector: #remove:
				arguments: {aNode}
				keystroke: $x
				icon: self deleteIcon)
		with: (OBAction
				label: 'rename...'
				receiver: self
				selector: #rename:
				arguments: {aNode})