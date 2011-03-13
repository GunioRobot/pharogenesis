addStayUpItem
	"Append a menu item that can be used to toggle this menu's persistent."

	self add: 'keep this menu up'
		target: self
		selector: #toggleStayUp:
		argumentList: EmptyArray.
