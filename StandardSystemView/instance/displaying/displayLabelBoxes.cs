displayLabelBoxes
	"closeBox, growBox."
	| aRect smallRect backColor |
	aRect _ self closeBoxFrame.
	backColor _ self labelColor.
	Display fill: (aRect insetBy: -2) fillColor: backColor.
	Display fillBlack: aRect.
	Display fill: (aRect insetBy: 1) fillColor: backColor.

	aRect _ self growBoxFrame.
	smallRect _ aRect origin extent: 7@7.
	Display fill: (aRect insetBy: -2) fillColor: backColor.
	aRect _ aRect insetOriginBy: 2@2 cornerBy: 0@0.
	Display fillBlack: aRect.
	Display fill: (aRect insetBy: 1) fillColor: backColor.
	Display fillBlack: smallRect.
	Display fill: (smallRect insetBy: 1) fillColor: backColor