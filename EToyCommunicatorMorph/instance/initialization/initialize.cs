initialize
	"initialize the state of the receiver"
	super initialize.
	""
	self vResizing: #shrinkWrap;
	 hResizing: #shrinkWrap.
	resultQueue _ SharedQueue new.
	fields _ Dictionary new.
	self useRoundedCorners