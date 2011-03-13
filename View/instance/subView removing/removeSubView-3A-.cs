removeSubView: aView 
	"Delete aView from the receiver's list of subViews. If the list of subViews 
	does not contain aView, create an error notification."

	subViews remove: aView.
	aView superView: nil.
	aView unlock