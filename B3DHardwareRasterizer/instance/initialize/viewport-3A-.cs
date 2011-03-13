viewport: vp
	super viewport: vp.
	self primSetViewportX: viewport left asInteger
			y: viewport top asInteger
			w: viewport width asInteger
			h: viewport height asInteger.