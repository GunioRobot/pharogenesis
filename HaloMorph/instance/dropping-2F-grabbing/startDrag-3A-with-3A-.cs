startDrag: evt with: dragHandle
	"Drag my target without removing it from its owner."

	| itsOwner |
	self obtainHaloForEvent: evt andRemoveAllHandlesBut: dragHandle.
	positionOffset _ dragHandle center - (target point: target position in: owner).

	 ((itsOwner _ target topRendererOrSelf owner) notNil and:
			[itsOwner automaticViewing]) ifTrue:
				[target openViewerForArgument]