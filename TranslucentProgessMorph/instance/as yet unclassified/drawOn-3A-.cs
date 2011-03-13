drawOn: aCanvas

	| revealPercentage revealingStyle revealingColor revealingBounds revealToggle x baseColor revealTimes secondsRemaining scanner stringToDraw where fontToUse innerBounds |
	
	innerBounds _ bounds.
	opaqueBackgroundColor ifNotNil: [
		aCanvas 
			frameAndFillRectangle: bounds
			fillColor: opaqueBackgroundColor
			borderWidth: 8
			borderColor: Color blue.
		innerBounds _ innerBounds insetBy: 8.
	].
	revealTimes _ (self valueOfProperty: #revealTimes) ifNil: [^self].
	revealPercentage _ (revealTimes first / revealTimes second) asFloat.
	revealingStyle _ self revealingStyle.
	x _ self valueOfProperty: #progressStageNumber ifAbsent: [1].
	baseColor _ Color perform: (#(red blue green magenta cyan yellow) atPin: x).
	revealingColor _ baseColor alpha: 0.2.
	revealingStyle = 3 ifTrue: [	"wrap and change color"
		revealPercentage > 1.0 ifTrue: [
			revealingColor _ baseColor alpha: (0.2 + (revealingStyle / 10) min: 0.5).
		].
		revealPercentage _ revealPercentage fractionPart.
	].
	revealingStyle = 2 ifTrue: [	"peg at 75 and blink"
		revealPercentage > 0.75 ifTrue: [
			revealToggle _ self valueOfProperty: #revealToggle ifAbsent: [true].
			self setProperty: #revealToggle toValue: revealToggle not.
			revealToggle ifTrue: [revealingColor _ baseColor alpha: 0.8.].
		].
		revealPercentage _ revealPercentage min: 0.75.
	].
	revealingBounds _ innerBounds withLeft: innerBounds left + (innerBounds width * revealPercentage) truncated.
	aCanvas 
		fillRectangle: revealingBounds
		color: revealingColor.
	secondsRemaining _ (revealTimes second - revealTimes first / 1000) rounded.
	secondsRemaining > 0 ifTrue: [
		fontToUse _ StrikeFont familyName: 'ComicBold' size: 24.
		scanner _ DisplayScanner
			quickPrintOn: aCanvas form 
			box: innerBounds 
			font: fontToUse 
			color: Color black.
		stringToDraw _ secondsRemaining printString.
		where _ innerBounds corner - ((scanner stringWidth: stringToDraw) @ scanner lineHeight).
		scanner 
			drawString: stringToDraw 
			at: where.
		scanner _ DisplayScanner
			quickPrintOn: aCanvas form 
			box: innerBounds 
			font: fontToUse 
			color: Color white.
		scanner 
			drawString: stringToDraw 
			at: where - (1@1).
	]. 


