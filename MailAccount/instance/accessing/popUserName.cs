popUserName
	popUserName isEmptyOrNil ifTrue:[
		self error: 'no POP user name specified'.
	].
	^ popUserName.	