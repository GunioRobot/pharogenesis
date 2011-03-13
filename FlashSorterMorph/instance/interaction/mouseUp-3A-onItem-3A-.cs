mouseUp: evt onItem: aMorph
	| pt |
	pt := evt cursorPoint.
	(aMorph bounds containsPoint: pt) ifTrue:[
		player stepToFrameSilently: aMorph frameNumber.
		^self].