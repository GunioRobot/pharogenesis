list: anArray

	super list: anArray.
	((Preferences valueOfFlag: #browserAutoSelect) and:
	 [list numberOfLines = 3]) ifTrue: [
		controller isNil ifFalse: [controller changeModelSelection: 1]].
