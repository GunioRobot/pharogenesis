addDirectionHandles

	| centerOfRotationHandle |
	((innerTarget isKindOf: SketchMorph) and: [innerTarget rotationStyle == #normal])
		ifTrue:
		[target player ifNotNil: [self addDirectionShaft].
		centerOfRotationHandle _ self
			addGraphicalHandle: #RotationCenter at: target referencePosition
				on: #mouseDown send: #prepareToTrackCenterOfRotation:with: to: self.
		centerOfRotationHandle
				on: #mouseStillDown send: #trackCenterOfRotation:with: to: self.
		centerOfRotationHandle
				on: #mouseUp send: #setCenterOfRotation:with: to: self]
