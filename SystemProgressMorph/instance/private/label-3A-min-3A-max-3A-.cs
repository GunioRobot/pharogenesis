label: shortDescription min: minValue max: maxValue
	| slot range newBarSize barSize lastRefresh |
	((range _ maxValue - minValue) <= 0 or: [(slot _ self nextSlotFor: shortDescription) = 0])
		ifTrue: [^[:barVal| 0 ]].
	self openInWorld.
	self align: self fullBounds center with: Display boundingBox center.
	barSize _ -1. "Enforces a inital draw of the morph"
	lastRefresh _ 0.
	^[:barVal | 
		(barVal between: minValue and: maxValue) ifTrue: [
			newBarSize _ (barVal - minValue / range * BarWidth) truncated.
			newBarSize = barSize ifFalse: [
				barSize _ newBarSize.
				(bars at: slot) barSize: barSize.
				Time primMillisecondClock - lastRefresh > 25 ifTrue: [
					self currentWorld displayWorld.
					lastRefresh _ Time primMillisecondClock]]].
		slot]
