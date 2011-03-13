reframePanesAdjoining: subView along: side to: aDisplayBox 
	| newBox delta newRect minDim |
	newRect _ aDisplayBox.
	"First check that this won't make any pane smaller than 8 screen dots"
	minDim _ ((subViews select: [:sub | sub displayBox bordersOn: subView displayBox along: side])
		collect: [:sub | self newDisplayBoxFor: sub adjoining: newRect along: side])
			inject: 999 into: [:was :rect | (was min: rect width) min: rect height].
	"If so, amend newRect as required"
	minDim < 8 ifTrue:
		[delta _ minDim - 8.
		newRect _ newRect withSide: side setTo: 
				((newRect perform: side) > (subView displayBox perform: side)
					ifTrue: [(newRect perform: side) + delta]
					ifFalse: [(newRect perform: side) - delta])].
	"Now adjust all adjoining panes for real"
	subViews do:
		[:sub | (sub displayBox bordersOn: subView displayBox along: side) ifTrue:
			[newBox _ self newDisplayBoxFor: sub adjoining: newRect along: side.
			sub window: sub window viewport:
				(sub transform: (sub inverseDisplayTransform: newBox)) rounded]].
	"And adjust the growing pane itself"
	subView window: subView window viewport:
			(subView transform: (subView inverseDisplayTransform: newRect)) rounded.

	"Finally force a recomposition of the whole window"
	viewport _ nil.
	self resizeTo: self viewport.
	self uncacheBits; displayEmphasized