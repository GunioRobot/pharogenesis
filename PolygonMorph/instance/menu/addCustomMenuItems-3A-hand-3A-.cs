addCustomMenuItems: aMenu hand: aHandMorph
	| lineName |
	super addCustomMenuItems: aMenu hand: aHandMorph.
	aMenu addUpdating: #handlesShowingPhrase target: self action: #showOrHideHandles.
	vertices size > 2 ifTrue:
		[aMenu addUpdating: #openOrClosePhrase target: self action: #makeOpenOrClosed.
		lineName _ (closed ifTrue: ['outline'] ifFalse: ['line']) translated.
		self isCurve
			ifTrue: [aMenu add: ('make segmented {1}' translated format: {lineName translated}) action: #toggleSmoothing]
			ifFalse: [aMenu add: ('make smooth {1}' translated format: {lineName translated}) action: #toggleSmoothing]]. 
	aMenu add: 'specify dashed line' translated action:  #specifyDashedLine.

	self isOpen ifTrue:
		[aMenu addLine.
		aMenu addWithLabel: '---' enablement: [self isOpen and: [arrows ~~ #none]] action:  #makeNoArrows.
		aMenu addWithLabel: '-->' enablement: [self isOpen and: [arrows ~~ #forward]] action:  #makeForwardArrow.
		aMenu addWithLabel: '<--' enablement: [self isOpen and: [arrows ~~ #back]] action:  #makeBackArrow.
		aMenu addWithLabel: '<->' enablement: [self isOpen and: [arrows ~~ #both]] action:  #makeBothArrows.
		aMenu add: 'customize arrows' translated action: #customizeArrows:.
		(self hasProperty: #arrowSpec)
			ifTrue: [aMenu add: 'standard arrows' translated action: #standardArrows]].