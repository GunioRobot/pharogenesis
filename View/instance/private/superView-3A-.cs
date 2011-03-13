superView: aView 
	"Set the View's superView to aView and unlock the View (see
	View|unlock). It is sent by View|addSubView: in order to properly set all
	the links."

	superView := aView.
	self unlock