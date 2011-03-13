addStayUpItemSpecial
	"Append a menu item that can be used to toggle this menu's persistent."

	"This variant is resistant to the MVC compatibility in #setInvokingView:"

	self add: 'keep this menu up'
		target: self
		selector: #toggleStayUpIgnore:evt:
		argumentList: #(1).
	self addLine