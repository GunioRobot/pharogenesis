addSubView: aSubView above: lowerView
	"Adds aView (see View|addSubView:) so that it lies above topView."

	self addSubView: aSubView
		align: aSubView viewport bottomLeft
		with: lowerView viewport topLeft