primGetAngleToX: pX toY: pY xArray: xArray yArray: yArray resultInto: result

	| ppx ppy x y ret |
	<primitive: 'vectorGetAngleTo' module:'KedamaPlugin'>
	"^ KedamaPlugin doPrimitive: #vectorGetAngleTo."

	ppx _ pX.
	ppy _ pY.
	1 to: result size do: [:index |
		pX isCollection ifTrue: [
			ppx _ pX at: index.
			ppy _ pY at: index.
		].
		x _ ppx - (xArray at: index).
		y _ ppy - (yArray at: index).
		ret _ (x@y) theta radiansToDegrees + 90.0.
		ret > 360.0 ifTrue: [ret _ ret - 360.0].
		result at: index put: ret.
	].
	^ result.
