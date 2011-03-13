actionsForParent: aNode
	^{OBAction
			label: 'add implementor' 
			receiver: self
			selector: #addImplementor:
			arguments: {aNode}
			keystroke: $a
			icon: self newIcon}