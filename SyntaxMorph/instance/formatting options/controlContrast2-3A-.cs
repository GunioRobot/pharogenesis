controlContrast2: evt

	| origin scale startingContrastX |

	evt isMouseUp ifTrue: [
		^self removeProperty: #startingPointForSomeAdjustment
	].
	evt isMouseDown ifTrue: [
		^self setProperty: #startingPointForSomeAdjustment toValue: evt cursorPoint
	].
	ContrastFactor ifNil: [ContrastFactor _ 0.5].
	scale _ 200.0.
	startingContrastX _ ContrastFactor * scale.
	origin _ self valueOfProperty: #startingPointForSomeAdjustment.
	ContrastFactor _ (evt cursorPoint x - origin x + startingContrastX) / scale min: 1.0 max: 0.0.
	self finalAppearanceTweaks.
