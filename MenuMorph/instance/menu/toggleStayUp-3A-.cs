toggleStayUp: evt
	"Toggle my 'stayUp' flag and adjust the menu item to reflect its new state."

	stayUp _ stayUp not.
	self items do: [:item |
		item selector = #toggleStayUp: ifTrue: [
			stayUp
				ifTrue: [item contents: 'dismiss this menu']
				ifFalse: [item contents: 'stay up']]].
	stayUp ifFalse: [self delete].
