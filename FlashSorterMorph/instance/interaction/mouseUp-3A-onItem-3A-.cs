mouseUp: evt onItem: aMorph
	| pt |
	pt _ evt cursorPoint.
	(aMorph bounds containsPoint: pt) ifTrue:[
		player stepToFrameSilently: aMorph frameNumber.
		^self].