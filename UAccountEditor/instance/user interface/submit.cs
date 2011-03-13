submit
	self acceptFields.
	newPassword = newPassword2 ifFalse: [
		^self inform: 'new passwords do not match!' ].
	whenDone value: password value: newPassword value: newEmail
	