startDrag: evt with: dragHandle
	| itsOwner |
	"Drag my target without removing it from its owner."

	self removeAllHandlesBut: dragHandle.
	positionOffset _ dragHandle center - target positionInWorld.

	 ((itsOwner _ target topRendererOrSelf owner) notNil and:
			[itsOwner automaticViewing]) ifTrue:
				[target openViewerForArgument]

