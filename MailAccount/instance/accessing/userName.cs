userName
	userName isEmptyOrNil ifTrue:[
		self error: 'no user name specified'.
	].
	^ userName.