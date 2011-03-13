actionsForParent: aNode
	^ Array with: (OBAction
						label: 'find class...'
						receiver: self
						selector: #findClassIn:
						arguments: (Array with: aNode environment)
						keystroke: $f)
