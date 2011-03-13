containsPoint: aPoint 
	"Answer whether aPoint is within the receiver's display box. It is sent to 
	a View's subViews by View|subViewAt: in order to determine which 
	subView contains the cursor point (so that, for example, control can be 
	pass down to that subView's controller).
	1/24/96 sw: use insetDisplayBox, so border doesn't count"

	^ self insetDisplayBox containsPoint: aPoint