drawOn: aCanvas 
	"Draw a rectangle with a solid, inset, or raised border.
	Note: the raised border color *and* the inset border color are generated
	from the receiver's own color, instead of having the inset border color
	generated from the owner's color, as in BorderedMorph."

	| font rct |

	borderWidth = 0 ifTrue: [  "no border"
		aCanvas fillRectangle: bounds color: color.
		^ self.].

	borderColor == #raised ifTrue: [
		^ aCanvas frameAndFillRectangle: bounds
			fillColor: color
			borderWidth: borderWidth
			topLeftColor: color lighter lighter
			bottomRightColor: color darker darker darker].

	borderColor == #inset ifTrue: [
		aCanvas frameAndFillRectangle: bounds
			fillColor: color
			borderWidth: 1 " borderWidth"
			topLeftColor: (color darker darker darker)
			bottomRightColor: color lighter.
		self isMine ifTrue: [  
			font  _ StrikeFont familyName: 'Atlanta' size: 22 emphasized: 1.
			rct _ bounds insetBy: ((bounds width) - (font widthOfString: '*'))/2@0.
			rct _ rct top: rct top + 1.
			aCanvas drawString: '*' in: (rct translateBy: 1@1) font: font color: Color black.
			^ aCanvas drawString: '*' in: rct font: font color: Color red .].
		self nearMines > 0 ifTrue: [ 
			font _ StrikeFont familyName: 'ComicBold' size: 22 emphasized: 1.
			rct _ bounds insetBy: ((bounds width) - (font widthOfString: nearMines asString))/2@0.
			rct _ rct top: rct top + 1.
			aCanvas drawString: nearMines asString in: (rct translateBy: 1@1) font: font color: Color black.
			^ aCanvas drawString: nearMines asString in: rct font: font color: ((palette at: nearMines) ) .].
		^self. ].

	"solid color border"
	aCanvas frameAndFillRectangle: bounds
		fillColor: color
		borderWidth: borderWidth
		borderColor: borderColor.