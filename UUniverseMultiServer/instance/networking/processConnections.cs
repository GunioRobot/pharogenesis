processConnections
	connections copy do: [ :c |
		self processConnection: c ]