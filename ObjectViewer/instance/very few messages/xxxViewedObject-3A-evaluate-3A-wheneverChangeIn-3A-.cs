xxxViewedObject: viewedObject evaluate: block1 wheneverChangeIn: block2
	"This message name must not clash with any other (natch)."
	tracedObject _ viewedObject.
	valueBlock _ block2.
	changeBlock _ block1.
	recursionFlag _ false