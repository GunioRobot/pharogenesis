specialDrag: evt
	"Special drag (cmd-mouse on the Macintosh) allows a morph to be dragged without grabbing it and thus without removing it from its owner or changing its z-order." 
	| halo itsOwner |
	self position ~= evt cursorPoint
		ifTrue: [self position: evt cursorPoint].
	mouseDownMorph
		ifNil:    ["Waiting for more than 5 pixels move to start drag"
				(self position dist: targetOffset) > 5
					ifTrue: [(halo _ self world haloMorphOrNil) ifNil: [^ self].
							mouseDownMorph _ halo target.
							targetOffset _ targetOffset - mouseDownMorph positionInWorld.
							halo removeAllHandlesBut: nil]]
		ifNotNil: [mouseDownMorph isWorldMorph ifFalse:
					[mouseDownMorph setConstrainedPositionFrom:
						(mouseDownMorph pointFromWorld: self position - targetOffset)].

	 mouseDownMorph ifNotNil:
		[((itsOwner _ mouseDownMorph topRendererOrSelf owner) notNil and:
			[itsOwner automaticViewing]) ifTrue:
				[mouseDownMorph openViewerForArgument]]]