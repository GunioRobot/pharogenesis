doOccluded: actionBlock
	| paneRect rectSet bottomStrip |
	paneRect := paragraph clippingRectangle.
	paragraph withClippingRectangle: (paneRect withHeight: 0)
		do: [actionBlock value.
			self scrollIn: paneRect].
	view topView isCollapsed ifTrue: [^ self].
	rectSet := self visibleAreas.
	bottomStrip := paneRect withTop: paragraph compositionRectangle bottom + 1.
	rectSet do:
		[:rect |
		(bottomStrip intersects: rect) ifTrue:
			["The subsequent displayOn should clear this strip but it doesnt"
			Display fill: (bottomStrip intersect: rect)
					fillColor: paragraph backgroundColor].
		paragraph withClippingRectangle: rect
				do: [paragraph displayOn: Display]]