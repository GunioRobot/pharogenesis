computeSpotFactor: light2Vertex
	"Compute the spot factor for a spot light"
	| lightDirection cosAngle minCos deltaCos maxCos |
	lightDirection _ self direction.
	cosAngle _ (lightDirection dot: light2Vertex) negated.
	(cosAngle < (minCos _ self hotSpotMinCosine)) ifTrue:[^0.0].
	maxCos _ self hotSpotMaxCosine.
"	maxCos = 1.0 ifFalse:["
		deltaCos _ self hotSpotDeltaCosine.
		deltaCos <= 0.00001 ifTrue:[
			"No delta -- a sharp boundary between on and off.
			Since off has already been determined above, we are on"
			^1.0].
		"Scale the angle to 0/1 range"
		cosAngle _ (cosAngle - minCos) / deltaCos.
		self flag: #TODO. "Don't scale by (maxCos - minCos)"
"	]."
	self flag: #TODO. "Use table lookup for spot exponent"
	^cosAngle raisedTo: self spotExponent