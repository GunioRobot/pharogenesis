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
		image borderWidth: 1
	].


