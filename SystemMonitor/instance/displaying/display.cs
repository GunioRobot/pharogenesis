display
	| barOrigin delta curVal minVal maxVal |
	self readVMParameters.
	barOrigin _ window topRight translateBy: (BarWidth negated - BarBorderWidth)@BarBorderWidth.
	delta _ 0@baselineSkip.
	1 to: valSelectors size do: [:index |
		curVal _ self perform: (valSelectors at: index).
		minVal _ minValues at: index.
		maxVal _ maxValues at: index.
		curVal class == Array
			ifTrue:
				["implicitly trust the system to return sensible values"
				self displayBars: curVal from: minVal to: maxVal
					in: (barOrigin extent: BarWidth@(baselineSkip - (BarBorderWidth * 2)))]
			ifFalse:
				["adjust the bounds if necessary"
				minVal > curVal ifTrue: [minValues at: index put: (minVal _ curVal)].
				maxVal < curVal ifTrue: [maxValues at: index put: (maxVal _ curVal)].
				self displayBar: curVal from: minVal to: maxVal
					in: (barOrigin extent: BarWidth@(baselineSkip - (BarBorderWidth * 2)))].
		barOrigin _ barOrigin translateBy: delta].