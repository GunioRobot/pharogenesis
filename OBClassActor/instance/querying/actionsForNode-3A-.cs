actionsForNode: aClassNode
	^ {OBAction
			label: 'remove' 
			receiver: self
			selector: #remove:
			arguments: {aClassNode}
			keystroke: $x 
			icon: self deleteIcon.
		OBAction
			label: 'rename...' 
			receiver: self
			selector: #rename:
			arguments: {aClassNode}.
		OBAction
			label: 'copy...' 
			receiver: self
			selector: #copy:
			arguments: {aClassNode}.
		OBAction
			label: 'subclass template'
			receiver: self
			selector: #subclassTemplate:
			arguments: {aClassNode}.
		OBAction
			label: 'browse references'
			receiver: self
			selector: #browseReferences:
			arguments: {aClassNode}
	}