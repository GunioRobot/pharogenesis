computeSpotFactor
	"Compute the spot factor for a spot light"
	| cosAngle minCos deltaCos |
	self returnTypeC:'double'.
	self var: #cosAngle declareC:'double cosAngle'.
	self var: #minCos declareC:'double minCos'.
	self var: #deltaCos declareC:'double deltaCos'.
	"Compute cos angle between direction of the spot light and direction to vertex"
	cosAngle _ self dotProductOfFloat: primLight + PrimLightDirection withDouble: l2vDirection.
	cosAngle _ 0.0 - cosAngle.
	minCos _ primLight at: SpotLightMinCos.
	cosAngle < minCos ifTrue:[^0.0].
	deltaCos _ primLight at: SpotLightDeltaCos.
	deltaCos <= 0.00001 ifTrue:[
		"No delta -- a sharp boundary between on and off.
		Since off has already been determined above, we are on"
		^1.0].
	"Scale the angle to 0/1 range"
	cosAngle _ (cosAngle - minCos) / deltaCos.
	^cosAngle raisedTo: (primLight at: SpotLightExponent)
