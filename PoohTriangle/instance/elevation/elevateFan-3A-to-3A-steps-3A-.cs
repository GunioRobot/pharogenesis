elevateFan: vertices to: elevationVertex steps: nSteps
	"Elevate the given edge of a junction"
	| lastVtx nextVtx faces |
	faces _ WriteStream on: #().
	lastVtx _ nextVtx _ nil.
	vertices reverseDo:[:pt|
		nextVtx _ self elevateFrom: (pt@0) to: elevationVertex steps: nSteps.
		lastVtx ifNotNil:[self elevateConnect: lastVtx with: nextVtx into: faces].
		lastVtx _ nextVtx.
	].
	^faces contents