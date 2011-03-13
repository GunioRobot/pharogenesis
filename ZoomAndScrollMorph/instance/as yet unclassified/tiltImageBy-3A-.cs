tiltImageBy: pixels

	self changeOffsetBy: 0 @ (pixels * self getTiltFactor * 0.1)

"	steps _ (pixels abs / 6) exp rounded * pixels sign.
"
"==Alan's preferred factors
pan = 0.0425531914893617
zoom = 0.099290780141844
==="
