pageBBox

	| pageSize offset bbox trueExtent |

	EPSCanvas bobsPostScriptHacks ifTrue: [
		trueExtent _ savedMorphExtent	"this one has been rotated"
	] ifFalse: [
		trueExtent _ psBounds extent
	].
	pageSize _ self defaultImageableArea.
	offset _ ((pageSize extent - trueExtent) / 2 max: 0@0) + self defaultMargin.
	bbox _ offset extent: psBounds extent.

	^bbox