drawSubmorphsOn: aCanvas

	aCanvas transformBy: transform
		clippingTo: self innerBounds
		during: [:myCanvas |
				submorphs reverseDo:[:m | myCanvas fullDrawMorph: m] ]
		smoothing: smoothing