initializeWidgets
	"initialize the receiver's widgets"
	self
		addMorph: (serverNameLabelWidget := self createLabel: 'Server Name:')
		frame: (0 @ 0 corner: 0.5 @ 0.33).
	self
		addMorph: (serverNameWidget := self createText: #serverName)
		frame: (0.5 @ 0 corner: 1 @ 0.33).
	""
	self
		addMorph: (portLabelWidget := self createLabel: 'Port:')
		frame: (0 @ 0.33 corner: 0.5 @ 0.67).
	self
		addMorph: (portWidget := self createText: #port)
		frame: (0.5 @ 0.33 corner: 1 @ 0.67).
	""
	self
		addMorph: (acceptWidget := self
						createButtonLabel: 'Accept'
						action: #accept
						help: 'Accept the proxy settings')
		frame: (0 @ 0.67 corner: 0.5 @ 1).
	self
		addMorph: (cancelWidget := self
						createButtonLabel: 'Cancel'
						action: #cancel
						help: 'Cancel the proxy settings')
		frame: (0.5 @ 0.67 corner: 1 @ 1)