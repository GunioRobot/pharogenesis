decompileScript: aScript named: aString for: aController

	| newMorphs prevPt prevScale cameraPoint cameraScale mark |

	self removeAllMorphs.
	self setProperty: #cameraController toValue: aController.
	self setProperty: #cameraScriptName toValue: aString.

	newMorphs _ OrderedCollection new.
	prevPt _ prevScale _ nil.
	aScript do: [ :each |
		cameraPoint _ each at: #startPoint ifAbsent: [nil].
		cameraScale _ each at: #startZoom ifAbsent: [nil].
		(prevPt = cameraPoint and: [prevScale = cameraScale]) ifFalse: [
			mark _ ZASMCameraMarkMorph new.
			mark cameraPoint: cameraPoint cameraScale: cameraScale controller: aController.
			newMorphs add: mark.
		].
		newMorphs add: (ZASMStepsMorph new setStepCount: (each at: #steps ifAbsent: [10])).
		cameraPoint _ each at: #endPoint ifAbsent: [nil].
		cameraScale _ each at: #endZoom ifAbsent: [nil].
		mark _ ZASMCameraMarkMorph new.
		mark cameraPoint: cameraPoint cameraScale: cameraScale controller: aController.
		newMorphs add: mark.
		prevPt _ cameraPoint.
		prevScale _ cameraScale.
	].
	self addAllMorphs: newMorphs.
