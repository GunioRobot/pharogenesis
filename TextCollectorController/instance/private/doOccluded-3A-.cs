doOccluded: actionBlock
	| paneRect rectSet bottomStrip |
	view topView isCollapsed ifTrue: [^ actionBlock value].
	paneRect _ paragraph clippingRectangle.
	rectSet _ self visibleAreas.
	paragraph withClippingRectangle: (paneRect withHeight: 0)
		do: [actionBlock value.
			self scrollIn: paneRect].
	bottomStrip _ paneRect withTop: paragraph compositionRectangle bottom + 1.
	rectSet do:
		[:rect |
		(bottomStrip intersects: rect) ifTrue:
			["The subsequent displayOn should clear this strip but it doesnt"
			Display fill: (bottomStrip intersect: rect)
					fillColor: paragraph backgroundColor].
		paragraph withClippingRectangle: rect
				do: [paragraph displayOn: Display]]