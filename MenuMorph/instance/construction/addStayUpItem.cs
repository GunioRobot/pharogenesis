addStayUpItem
	"Append a menu item that can be used to toggle this menu's persistent."

	self add: 'stay up'
		target: self
		selector: #toggleStayUp:
		argumentList: EmptyArray.
