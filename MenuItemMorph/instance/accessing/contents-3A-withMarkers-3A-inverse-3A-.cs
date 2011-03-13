contents: aString withMarkers: aBool inverse: inverse
	"Set the menu item entry. If aBool is true, parse aString for embedded markers."
	| markerIndex marker indent |
	self contentString: nil. "get rid of old"
	aBool ifFalse:[^super contents: aString].
	self removeAllMorphs. "get rid of old markers if updating"
	(aString at: 1) = $< ifFalse:[^super contents: aString].
	markerIndex _ aString indexOf: $>.
	markerIndex = 0 ifTrue:[^super contents: aString].
	marker _ (aString copyFrom: 1 to: markerIndex) asLowercase.
	(#('<on>' '<off>' '<yes>' '<no>') includes: marker) ifFalse:[^super contents: aString].
	self contentString: aString. "remember actual string"
	(marker = '<on>' or:[marker = '<yes>']) ~= inverse
		ifTrue:[marker _ self onImage]
		ifFalse:[marker _ self offImage].
	"Indent the string using white spaces"
	indent _ ' '.
	font _ self fontToUse.
	[ (font widthOfString: indent) < (marker width + 4) ] 
		whileTrue:[indent _ indent copyWith: Character space].
	"Set the string"
	super contents: indent, (aString copyFrom: markerIndex+1 to: aString size).
	"And set the marker"
	marker _ ImageMorph new image: marker.
	marker position: (self left) @ (self top + 2).
	self addMorphFront: marker.