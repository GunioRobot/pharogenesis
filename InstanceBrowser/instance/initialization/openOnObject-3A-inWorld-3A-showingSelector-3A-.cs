openOnObject: anObject inWorld: aWorld showingSelector: aSelector
	"Create and open a SystemWindow to house the receiver, showing the categories pane."

	objectViewed _ anObject.
	self openOnClass: anObject class inWorld: aWorld showingSelector: aSelector