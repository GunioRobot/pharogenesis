queryProjects: criteria
	| result |
	"SuperSwikiServer defaultSuperSwiki queryProjects: #('submittedBy: mir' )"
	result _ self sendToSwikiProjectServer: {
		'action: findproject'.
	}  , criteria.
	(result beginsWith: 'OK') ifFalse: [^self inform: result printString].
	^self parseQueryResult: (ReadStream on: result).
