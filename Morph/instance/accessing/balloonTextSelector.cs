balloonTextSelector
	"Answer balloon text selector item in the extension, nil if none"
	^ self hasExtension
		ifTrue: [self extension balloonTextSelector]