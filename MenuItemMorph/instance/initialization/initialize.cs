initialize
	"initialize the state of the receiver"
	super initialize.
	""
	
	contents _ ''.
	hasFocus _ false.
	isEnabled _ true.
	subMenu _ nil.
	isSelected _ false.
	target _ nil.
	selector _ nil.
	arguments _ nil.
	font _ Preferences standardMenuFont.
	self hResizing: #spaceFill;
		 vResizing: #shrinkWrap