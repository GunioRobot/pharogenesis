hideScrollBarIndefinitely
	"Get rid of scroll bar for short panes that don't want it shown."

	self setProperty: #noScrollBarPlease toValue: true.
	self hideScrollBar.

