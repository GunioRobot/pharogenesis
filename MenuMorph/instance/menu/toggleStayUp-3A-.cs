toggleStayUp: evt
	"Toggle my 'stayUp' flag and adjust the menu item to reflect its new state."

	self items do: [:item |
		item selector = #toggleStayUp: ifTrue:
			[stayUp _ stayUp not.	
			 stayUp
				ifTrue: [item contents: 'dismiss this menu']
				ifFalse: [item contents: 'keep this menu up']]].
	stayUp ifFalse: [self topRendererOrSelf delete].
