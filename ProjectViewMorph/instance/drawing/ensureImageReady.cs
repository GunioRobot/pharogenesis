ensureImageReady

	self isTheRealProjectPresent ifFalse: [^self].
	project thumbnail ifNil: [
		image fill: image boundingBox rule: Form over 
			fillColor: project defaultBackgroundColor.
		^self
	].
	project thumbnail ~~ lastProjectThumbnail ifTrue: ["scale thumbnail to fit my bounds"
		lastProjectThumbnail _ project thumbnail.
		self updateImageFrom: lastProjectThumbnail.
		project thumbnail ifNotNil: [project thumbnail hibernate].
		image borderWidth: 1
	].


