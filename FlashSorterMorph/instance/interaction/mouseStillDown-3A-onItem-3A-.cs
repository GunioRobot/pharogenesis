mouseStillDown: evt onItem: aMorph
	| pt index m yOffset |
	submorphs do:[:mm|
		mm == aMorph ifFalse:[mm isSelected: false]].
	pt _ evt cursorPoint.
	yOffset _ self offset y.
	index _ aMorph frameNumber. "What a fake hack@!"
	pt y - yOffset < 0 ifTrue:[
		owner scrollBy: 0@owner scrollDeltaHeight].
	pt y - yOffset > self extent y ifTrue:[
		owner scrollBy: 0@owner scrollDeltaHeight negated].
	(aMorph bounds containsPoint: pt) ifTrue:[^self].
	(pt y > aMorph bottom or:[pt x > aMorph right]) ifTrue:[
		"Select all morphs forward."
		index+1 to: submorphs size do:[:i|
			m _ submorphs at: i.
			m isSelected: aMorph isSelected.
			(m bounds containsPoint: pt) ifTrue:[^self]. "Done"
		].
		^self].
	"Select morphs backwards"
	index-1 to: 1 by: -1 do:[:i|
		m _ submorphs at: i.
		m isSelected: aMorph isSelected.
		(m bounds containsPoint: pt) ifTrue:[^self].
	].