behaveLikeHolder: aBoolean
 	"Change the receiver's viewing properties such that they conform to what we commonly call a Holder, viz: resize-to-fit, do auto-line-layout, and indicate the 'cursor'"

	self resizeToFit: aBoolean; autoLineLayout: aBoolean; indicateCursor: aBoolean
	