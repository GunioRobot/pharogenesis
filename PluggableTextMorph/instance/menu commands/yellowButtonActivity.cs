yellowButtonActivity
	"Called when the shifted-menu's 'more' item is chosen"

	| menu |
	(menu _ self getMenu: false) ifNotNil:
		["Set up to use perform:orSendTo: for model/view dispatch"
		menu setInvokingView: self.
		menu invokeModal]