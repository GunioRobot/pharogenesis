menuItemForAction: aServiceAction 
	"Returns a menuItem triggering self"
	self menu
		add: (aServiceAction menuLabelNumbered: self n)
		target: aServiceAction
		selector: #execute.
	self menu lastItem isEnabled: aServiceAction executeCondition.
	self menu balloonTextForLastItem: aServiceAction description