fullScreen
	"Expand the receiver to fill the screen.  Let the model decide how big is full -- allows for flop-out scrollbar on left if desired"

	self isCollapsed ifFalse:
		[self reframeTo: model fullScreenSize]