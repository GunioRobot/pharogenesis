queryProjectsAndShow
	| result |
"SuperSwikiServer testOnlySuperSwiki queryProjectsAndShow"

	result _ self sendToSwikiProjectServer: {
		'action: findproject'.
		"'projectname: *proj*'."
	}.
	(result beginsWith: 'OK') ifFalse: [^self inform: result printString].
	self showQueryAsPVM: (ReadStream on: result).
