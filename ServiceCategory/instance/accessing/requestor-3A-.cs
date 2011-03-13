requestor: aRequestor
	super requestor: aRequestor.
	self services do: [:s | s requestor: aRequestor]