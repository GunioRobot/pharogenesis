spawnOffsetReframeHandle: event divider: divider
	"The mouse has crossed a secondary (fixed-height) pane divider.  Spawn a reframe handle."
	"Only supports vertical adjustments."
	| siblings topAdjustees bottomAdjustees topOnly bottomOnly resizer pt delta minY maxY |
	allowReframeHandles ifFalse: [^ self].
	owner ifNil: [^ self  "Spurious mouseLeave due to delete"].
	(self isActive not or: [self isCollapsed]) ifTrue:  [^ self].
	((self world ifNil: [^ self]) firstSubmorph isKindOf: NewHandleMorph) ifTrue:
		[^ self  "Prevent multiple handles"].
	divider layoutFrame ifNil: [^ self].
	(#(top bottom) includes: divider resizingEdge) ifFalse: [^ self].

	siblings _ divider owner submorphs select: [:m | m layoutFrame notNil ].
	divider resizingEdge = #bottom ifTrue:
		[
		topAdjustees _ siblings select: [:m |
			m layoutFrame topFraction = divider layoutFrame bottomFraction and:
				[m layoutFrame topOffset >= divider layoutFrame topOffset] ].
		bottomAdjustees _ siblings select: [:m |
			m layoutFrame bottomFraction = divider layoutFrame topFraction and:
				[m layoutFrame bottomOffset >= divider layoutFrame topOffset] ].
		].
	divider resizingEdge = #top ifTrue:
		[
		topAdjustees _ siblings select: [:m |
			m layoutFrame topFraction = divider layoutFrame bottomFraction and:
				[m layoutFrame topOffset <= divider layoutFrame bottomOffset] ].
		bottomAdjustees _ siblings select: [:m |
			m layoutFrame bottomFraction = divider layoutFrame topFraction and:
				[m layoutFrame bottomOffset <= divider layoutFrame bottomOffset] ].
		].
	topOnly := topAdjustees copyWithoutAll: bottomAdjustees.
	bottomOnly := bottomAdjustees copyWithoutAll: topAdjustees.
	(topOnly isEmpty or: [bottomOnly isEmpty]) ifTrue: [^self].

	minY := bottomOnly inject: -9999 into: [:y :m | 
		y max: m top + (m minHeight max: 16) + (divider bottom - m bottom)].
	maxY := topOnly inject: 9999 into: [:y :m |
		y min: m bottom - (m minHeight max: 16) - (m top - divider top)].

	pt _ event cursorPoint.
	resizer _ NewHandleMorph new
		followHand: event hand
		forEachPointDo: [:p |
			delta := (p y min: maxY max: minY) - pt y.
			topAdjustees do:
				[:m | m layoutFrame topOffset: m layoutFrame topOffset + delta ].
			bottomAdjustees do:
				[:m | m layoutFrame bottomOffset: m layoutFrame bottomOffset + delta ].
			divider layoutChanged.
			pt := pt + delta.
		]
		lastPointDo: [:p | ].
	event hand world addMorphInLayer: resizer.
	resizer startStepping