initialize
	"initialize the state of the receiver"
	super initialize.
	""

	self layoutInset: 4.
	self hResizing: #shrinkWrap.
	self vResizing: #shrinkWrap.
	thingsToRevert _ Dictionary new.
	self useRoundedCorners