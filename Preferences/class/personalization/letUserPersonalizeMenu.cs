letUserPersonalizeMenu
	"Invoked from menu, opens up a single-msg browser on the message that user is invited to customize for rapid morphic access via option-click on morphic desktop"

	Browser openMessageBrowserForClass: Preferences class 
		selector: #personalizeUserMenu: editString: nil