startDrag: evt with: dragHandle
	| itsOwner |
	"Drag my target without removing it from its owner."
	evt hand obtainHalo: self.
	self removeAllHandlesBut: dragHandle.
	positionOffset _ dragHandle center - (target point: target position in: owner).

	 ((itsOwner _ target topRendererOrSelf owner) notNil and:
			[itsOwner automaticViewing]) ifTrue:
				[target openViewerForArgument]

"
Smalltalk at: #Q put: OrderedCollection new
"
