scrollBarValue: scrollValue

	| newPt pageBreaks topOfPage |

	scroller hasSubmorphs ifFalse: [^ self].
	newPt _ -3 @ (self vLeftoverScrollRange * scrollValue).

	pageBreaks _ self valueOfProperty: #pageBreakRectangles ifAbsent: [#()].
	pageBreaks isEmpty ifTrue: [
		^scroller offset: newPt.
	].
	topOfPage _ pageBreaks inject: (0@0 corner: 0@0) into: [ :closest :each |
		(each bottom - newPt y) abs < (closest bottom - newPt y) abs ifTrue: [
			each 
		] ifFalse: [
			closest 
		].
	].
	topOfPage ifNotNil: [
		newPt _ newPt x @ topOfPage bottom.
		scrollBar value: newPt y / self vLeftoverScrollRange.
	].
	scroller offset: newPt.