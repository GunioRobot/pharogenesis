categorizeActionFor: aNode
	^ OBAction
		label: 'categorize automatically'
		receiver: self
		selector: #categorizeIn:
		arguments: (Array with: aNode organization)