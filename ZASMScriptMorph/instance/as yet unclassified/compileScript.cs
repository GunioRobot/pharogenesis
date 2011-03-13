compileScript

	| newScript prevMark prevSteps data |

	self fixup.
	newScript _ OrderedCollection new.
	prevMark _ prevSteps _ nil.
	submorphs do: [ :each |
		(each isKindOf: ZASMCameraMarkMorph) ifTrue: [
			prevMark ifNotNil: [
				data _ Dictionary new.
				data 
					at: #steps put: prevSteps;
					at: #startPoint put: (prevMark valueOfProperty: #cameraPoint);
					at: #endPoint put: (each valueOfProperty: #cameraPoint);
					at: #startZoom put: (prevMark valueOfProperty: #cameraScale);
					at: #endZoom put: (each valueOfProperty: #cameraScale).
				newScript add: data.
			].
			prevMark _ each.
		].
		(each isKindOf: ZASMStepsMorph) ifTrue: [
			prevSteps _ each getStepCount.
		].
	].
	^newScript
