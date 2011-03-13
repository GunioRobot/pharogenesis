menuItemForCategory: aServiceCategory 
	"Returns a menuItem triggering self"
	| submenu |
	submenu := self subMenuFor: aServiceCategory.
	self menu add: (aServiceCategory menuLabelNumbered: self n) subMenu: submenu