initializePass2
	"The receiver is about to be drawn.
	Initialize all the attributes deferred until now."
	| majorDv minorDv dvdx dvdy w0 w1 w2 baseValue rAttr gAttr bAttr aAttr wAttr sAttr tAttr |
	"Red"
	majorDv _ v2 redValue - v0 redValue.
	minorDv _ v1 redValue - v0 redValue.
	dvdx _ oneOverArea * ((majorDv * minorDy) - (minorDv * majorDy)).
	dvdy _ oneOverArea * ((majorDx * minorDv) - (majorDv * minorDx)).
	attributes _ rAttr _ B3DPrimitiveFaceAttributes new.
	rAttr value: v0 redValue; dvdx: dvdx; dvdy: dvdy.
	"Green"
	majorDv _ v2 greenValue - v0 greenValue.
	minorDv _ v1 greenValue - v0 greenValue.
	dvdx _ oneOverArea * ((majorDv * minorDy) - (minorDv * majorDy)).
	dvdy _ oneOverArea * ((majorDx * minorDv) - (majorDv * minorDx)).
	gAttr _ B3DPrimitiveFaceAttributes new.
	gAttr value: v0 greenValue; dvdx: dvdx; dvdy: dvdy.
	rAttr nextAttr: gAttr.
	"Blue"
	majorDv _ v2 blueValue - v0 blueValue.
	minorDv _ v1 blueValue - v0 blueValue.
	dvdx _ oneOverArea * ((majorDv * minorDy) - (minorDv * majorDy)).
	dvdy _ oneOverArea * ((majorDx * minorDv) - (majorDv * minorDx)).
	bAttr _ B3DPrimitiveFaceAttributes new.
	bAttr value: v0 blueValue; dvdx: dvdx; dvdy: dvdy.
	gAttr nextAttr: bAttr.
	"Alpha"
	majorDv _ v2 alphaValue - v0 alphaValue.
	minorDv _ v1 alphaValue - v0 alphaValue.
	dvdx _ oneOverArea * ((majorDv * minorDy) - (minorDv * majorDy)).
	dvdy _ oneOverArea * ((majorDx * minorDv) - (majorDv * minorDx)).
	aAttr _ B3DPrimitiveFaceAttributes new.
	aAttr value: v0 alphaValue; dvdx: dvdx; dvdy: dvdy.
	bAttr nextAttr: aAttr.

	"W part"
	texture == nil ifFalse:[
		w0 _ v0 rasterPosW. w1 _ v1 rasterPosW. w2 _ v2 rasterPosW.
		majorDv _ w2 - w0.
		minorDv _ w1 - w0.
		dvdx _ oneOverArea * ((majorDv * minorDy) - (minorDv * majorDy)).
		dvdy _ oneOverArea * ((majorDx * minorDv) - (majorDv * minorDx)).
		wAttr _ B3DPrimitiveFaceAttributes new.
		wAttr value: w0; dvdx: dvdx; dvdy: dvdy.
		aAttr nextAttr: wAttr.

		baseValue _ v0 texCoordS * w0.
		majorDv _ (v2 texCoordS * w2) - baseValue.
		minorDv _ (v1 texCoordS * w1) - baseValue.
		dvdx _ oneOverArea * ((majorDv * minorDy) - (minorDv * majorDy)).
		dvdy _ oneOverArea * ((majorDx * minorDv) - (majorDv * minorDx)).
		sAttr _ B3DPrimitiveFaceAttributes new.
		sAttr value: baseValue; dvdx: dvdx; dvdy: dvdy.
		wAttr nextAttr: sAttr.

		baseValue _ v0 texCoordT * w0.
		majorDv _ (v2 texCoordT * w2) - baseValue.
		minorDv _ (v1 texCoordT * w1) - baseValue.
		dvdx _ oneOverArea * ((majorDv * minorDy) - (minorDv * majorDy)).
		dvdy _ oneOverArea * ((majorDx * minorDv) - (majorDv * minorDx)).
		tAttr _ B3DPrimitiveFaceAttributes new.
		tAttr value: baseValue; dvdx: dvdx; dvdy: dvdy.
		sAttr nextAttr: tAttr.
	].