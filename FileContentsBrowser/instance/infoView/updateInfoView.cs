updateInfoView

	Smalltalk isMorphic 
		ifTrue: [self changed: #infoViewContents]
		ifFalse: [
			self infoString contents: self infoViewContents.
			self infoString changed].