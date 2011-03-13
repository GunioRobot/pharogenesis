primGetDistanceToX: pX toY: pY xArray: xArray yArray: yArray resultInto: result

	| ppx ppy |
	<primitive: 'vectorGetDistanceTo' module:'KedamaPlugin'>
	"^ KedamaPlugin doPrimitive: #vectorGetDistanceTo."

	ppx _ pX.
	ppy _ pY.
	1 to: result size do: [:index |
		pX isCollection ifTrue: [
			ppx _ pX at: index.
			ppy _ pY at: index.
		].
		result at: index put: ((ppx - (xArray at: index)) squared + (ppy - (yArray at: index)) squared) sqrt.

	].
	^ result.
