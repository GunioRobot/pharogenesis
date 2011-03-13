addSubView: aSubView toRightOf: leftView
	"Add the argument, aSubView, (see View|addSubView:) so that it lies to 
	the right of the view, leftView."

	self addSubView: aSubView
		align: aSubView viewport topLeft
		with: leftView viewport topRight