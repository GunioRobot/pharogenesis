accept
	model okToChange ifFalse: [^ self].
	self controlTerminate.
	super accept.
	model newListAndPattern: paragraph text string.
	self controlInitialize