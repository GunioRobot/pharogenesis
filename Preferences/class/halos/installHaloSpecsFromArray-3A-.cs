installHaloSpecsFromArray: anArray

	| aColor |
	^ Parameters at: #HaloSpecs put: 
		(anArray collect:
			[:quin |
				aColor _ Color.
				quin fourth do: [:sel | aColor _ aColor perform: sel].
				HaloSpec new 
					horizontalPlacement: quin second
					verticalPlacement: quin third 
					color: aColor
					iconSymbol: quin fifth
					addHandleSelector: quin first])