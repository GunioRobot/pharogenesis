addFlutter
	"Add F0 flutter, as specified in:
		'Analysis, synthesis and perception of voice quality variations among
		female and male talkers' D.H. Klatt and L.C. Klatt JASA 87(2) February 1990.
	Flutter is added by applying a quasi-random element constructed from three
	slowly varying sine waves."
	| timeCount asin bsin csin deltaF0 |
	self returnTypeC: 'void'.
	self var: 'timeCount' declareC: 'float timeCount'.
	self var: 'asin' declareC: 'float asin'.
	self var: 'bsin' declareC: 'float bsin'.
	self var: 'csin' declareC: 'float csin'.
	self var: 'deltaF0' declareC: 'double deltaF0'.
	timeCount _ (self cCoerce: samplesCount to: 'float') / (self cCoerce: samplingRate to: 'float').
	asin _ (2.0 * PI * 12.7 * timeCount) sin.
	bsin _ (2.0 * PI * 7.1 * timeCount) sin.
	csin _ (2.0 * PI * 4.7 * timeCount) sin.
	deltaF0 _ (frame at: Flutter) * 2.0 * (frame at: F0) / 100.0 * (asin + bsin + csin).
	pitch _ pitch + deltaF0