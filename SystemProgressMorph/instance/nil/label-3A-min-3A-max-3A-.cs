label: shortDescription min: startMinValue max: startMaxValue
	"Answer the block that updates the progress bar."
	
	"some fun stuff added (by kph)
	
	- bar value: #label. - tell me my current label.
	- bar value: 'newLabel'. - enable changing the label from within the workBlock
	- bar value: #increment. - enable progress by one without keeping a counter
	- bar value: #decrement. - go backwards (if you really have to, useful for an abort, or rollback)!
 
	- bar value: newBigNum. - change the max on the fly - when you find there is more to do.
	- bar value: (bar value: #setMax) + 20 - change the max on the fly - when you find there is more/less to do.
	- bar value: (bar value: #setMin) - 20 - change the min on the fly - not sure why you would want to.
	- bar value: #stripe to be debugged

	"
	| slot range newBarSize barSize lastRefresh maxValue  minValue bar|
	maxValue := startMaxValue.
	minValue := startMinValue.
	((range := maxValue - minValue) <= 0 or: [(slot := self nextSlotFor: shortDescription) = 0])
		ifTrue: [^[:barVal| 0 ]].
	self openInWorld.
	self align: self fullBounds center with: Display boundingBox center.
	barSize := -1. "Enforces a inital draw of the morph"
	lastRefresh := Time millisecondClockValue.
	bar := bars at: slot.
	bar removeProperty: #useStripe.
	(bar valueOfProperty: #nonStripedFillStyle) ifNotNilDo: [:fs |
		bar fillStyle: fs.
		bar removeProperty: #nonStripedFillStyle].	 "force reset of fill style if striped"
	^[:barValArg | | barVal return  |
		barVal := barValArg.
		return := nil.
		bar := bars at: slot.
		"new fun stuff here"
		barVal == #current  ifTrue: [ return := barSize ].
		barVal == #label ifTrue:[ return := (labels at: slot) contents ].
		barVal == #setMax ifTrue: [ return := maxValue. maxValue := minValue ].
		barVal == #setMin ifTrue: [ return := minValue. minValue := maxValue ].
		barVal == #stripe
			ifTrue: [bar setProperty: #useStripes toValue: true.
					bar setProperty: #nonStripedFillStyle toValue: bar fillStyle.
					bar fillStyle: ((GradientFillStyle ramp: ((1 to: 20)
								collect: [:i| Association key: (i/20.0) value: (i even
											ifTrue: [ Color white ]
											ifFalse: [Color cyan])]))
						origin: bar position;
						direction: 300@0;
						radial: false;
						yourself).
					barVal := #refresh].
		barVal == #increment ifTrue: [return := barVal := barSize + 1].
		barVal == #decrement ifTrue: [ return := barVal := barSize - 1].
		(barVal isString and: [barVal isSymbol not]) ifTrue: [
			(labels at: slot) contents: barVal. 
			barVal := #refresh].
		barVal == #refresh ifTrue: [self currentWorld displayWorld. return := true].	
		(barVal == SmallInteger maxVal or: [ barVal == #finished ]) ifTrue: [return := slot].	 
		return ifNil: [
			barVal > maxValue ifTrue: [return := maxValue := barVal].
			barVal < minValue ifTrue: [return := minValue := barVal].
			(barVal between: minValue and: maxValue)
				ifTrue: [newBarSize := (barVal - minValue / range * BarWidth) truncated.
						newBarSize = barSize
							ifFalse: [barSize := newBarSize.
									(Time millisecondsSince: lastRefresh) > 25
										ifTrue: [barVal := #refresh ]]].	
		barVal == #refresh ifTrue: [
					((bar valueOfProperty: #useStripes) ifNil: [false])
						ifTrue: [bar fillStyle origin: bar position - ((Time millisecondClockValue // 50 \\ 30) @ 0)].
					bar barSize: barSize.
					self currentWorld displayWorld.
					lastRefresh := Time millisecondClockValue]].
		return]