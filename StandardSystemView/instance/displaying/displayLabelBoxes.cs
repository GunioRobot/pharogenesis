displayLabelBoxes
	"closeBox, growBox."
	| aRect smallRect backColor |
	aRect := self closeBoxFrame.
	backColor := self labelColor.
	Display fill: (aRect insetBy: -2) fillColor: backColor.
	Display fillBlack: aRect.
	Display fill: (aRect insetBy: 1) fillColor: backColor.

	aRect := self growBoxFrame.
	smallRect := aRect origin extent: 7@7.
	Display fill: (aRect insetBy: -2) fillColor: backColor.
	aRect := aRect insetOriginBy: 2@2 cornerBy: 0@0.
	Display fillBlack: aRect.
	Display fill: (aRect insetBy: 1) fillColor: backColor.
	Display fillBlack: smallRect.
	Display fill: (smallRect insetBy: 1) fillColor: backColor