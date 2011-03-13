setInvokingView: invokingView
	"Re-work every menu item of the form
		<target> perform: <selector>
	to the form
		<target> perform: <selector> orSendTo: <invokingView>.
	This supports MVC's vectoring of non-model messages to the editPane."
	self items do:
		[:item |
		item arguments isEmpty ifTrue:  "only the simple messages"
			[item arguments: (Array with: item selector with: invokingView).
			item selector: #perform:orSendTo:]]