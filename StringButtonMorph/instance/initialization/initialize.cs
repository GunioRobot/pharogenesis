initialize
	"initialize the state of the receiver"
	super initialize.
	""
	target _ nil.
	actionSelector _ #flash.
	arguments _ EmptyArray.
	actWhen _ #buttonUp.
	self contents: 'Flash' 