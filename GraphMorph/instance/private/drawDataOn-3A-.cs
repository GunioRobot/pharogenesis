drawDataOn: aCanvas

	| yScale baseLine x start end value left top bottom right |
	super drawOn: aCanvas.

	data isEmpty ifTrue: [^ self].
	maxVal = minVal ifTrue: [
		yScale _ 1.
	] ifFalse: [
		yScale _ (bounds height - (2 * borderWidth)) asFloat / (maxVal - minVal)].
	baseLine _ bounds bottom - borderWidth + (minVal * yScale) truncated.
	left _ top _ 0. right _ 10. bottom _ 0.
	x _ bounds left + borderWidth.
	start _ (startIndex asInteger max: 1) min: data size.
	end _ (start + bounds width) min: data size.
	start to: end do: [:i |
		left _ x truncated. right _ x + 1.
		right > (bounds right - borderWidth) ifTrue: [^ self].
		value _ (data at: i) asFloat.
		value >= 0.0 ifTrue: [
			top _ baseLine - (yScale * value) truncated.
			bottom _ baseLine.
		] ifFalse: [
			top _ baseLine.
			bottom _ baseLine - (yScale * value) truncated].
		aCanvas fillRectangle: (left@top corner: right@bottom) color: dataColor.
		x _ x + 1].
