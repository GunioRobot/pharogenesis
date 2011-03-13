drawWindowDropShadowFor: aSystemWindow on: aCanvas
	"Draw the drop shadow for the given window."
	
	aCanvas 
		translateBy: aSystemWindow shadowOffset 
		during: [ :shadowCanvas |
			shadowCanvas shadowColor: aSystemWindow shadowColor.
			shadowCanvas roundCornersOf: aSystemWindow during: [ 
				(shadowCanvas isVisible: aSystemWindow bounds) ifTrue: [
					shadowCanvas drawMorph: aSystemWindow]]]
