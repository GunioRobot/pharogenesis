openEToyPanel
	| toySystem |
	toySystem _ Smalltalk at: #EToySystem ifAbsent: [^ self inform: 'Sorry, this system does not support EToys'].
	toySystem openEToyControls