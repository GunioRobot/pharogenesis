drawSubmorphsOn: aCanvas
	| aaLevel |
	aCanvas asBalloonCanvas preserveStateDuring:[:myCanvas|
		colorTransform ifNotNil:[myCanvas colorTransformBy: colorTransform].
		(aaLevel := self defaultAALevel) ifNotNil:[myCanvas aaLevel: aaLevel].
		super drawSubmorphsOn: myCanvas].