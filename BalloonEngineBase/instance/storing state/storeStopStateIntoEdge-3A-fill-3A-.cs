storeStopStateIntoEdge: edgeOop fill: fillOop
	| reason edge |
	reason _ self stopReasonGet.

	reason = GErrorGETEntry ifTrue:[
		edge _ getBuffer at: self getStartGet.
		self storeEdgeStateFrom: edge into: edgeOop.
		self getStartPut: self getStartGet + 1.
	].

	reason = GErrorFillEntry ifTrue:[
		self storeFillStateInto: fillOop.
	].

	reason = GErrorAETEntry ifTrue:[
		edge _ aetBuffer at: self aetStartGet.
		self storeEdgeStateFrom: edge into: edgeOop.
		"Do not advance to the next aet entry yet"
		"self aetStartPut: self aetStartGet + 1."
	].