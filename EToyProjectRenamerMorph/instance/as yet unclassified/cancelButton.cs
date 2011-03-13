cancelButton

	^self
		buttonNamed: 'Cancel' 
		action: #doCancel 
		color: self buttonColor 
		help: 'Cancel this Publish operation.'