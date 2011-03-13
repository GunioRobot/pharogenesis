queryProjectsAndShow: thingsToSearchFor
	| result |
"SuperSwikiServer testOnlySuperSwiki queryProjectsAndShow"

	result _ self sendToSwikiProjectServer: {
		'action: findproject'.
	}, thingsToSearchFor.
	(result beginsWith: 'OK') ifFalse: [^self inform: result printString].
	self showQueryAsPVM: (ReadStream on: result).
