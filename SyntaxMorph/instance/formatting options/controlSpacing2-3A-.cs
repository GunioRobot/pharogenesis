controlSpacing2: evt

	| origin scale startingContrastX |

	evt isMouseUp ifTrue: [
		^self removeProperty: #startingPointForSomeAdjustment
	].
	evt isMouseDown ifTrue: [
		^self setProperty: #startingPointForSomeAdjustment toValue: evt cursorPoint
	].
	SizeScaleFactor ifNil: [SizeScaleFactor _ 0.15].
	scale _ 200.0.
	startingContrastX _ SizeScaleFactor * scale.
	origin _ self valueOfProperty: #startingPointForSomeAdjustment.
	SizeScaleFactor _ (evt cursorPoint x - origin x + startingContrastX) / scale min: 1.0 max: 0.0.
	self finalAppearanceTweaks.
