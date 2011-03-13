currentClassName: aString

	currentClassName _ aString.
	currentSelector _ nil.	"fix by wod"
	self changed: #currentClassName.
	self changed: #messageList.
	self setContents.
	self changed: #contents.