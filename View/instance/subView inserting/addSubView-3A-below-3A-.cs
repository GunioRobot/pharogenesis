addSubView: aSubView below: lowerView
	"Add the argument, aSubView, (see View|addSubView:) so that it lies 
	below the view, topView."

	self addSubView: aSubView
		align: aSubView viewport topLeft
		with: lowerView viewport bottomLeft