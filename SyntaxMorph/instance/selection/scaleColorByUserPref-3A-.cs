scaleColorByUserPref: aColor
	
	| myRoot underLyingColor |

	myRoot _ self rootTile.
	underLyingColor _ myRoot ifNil: [Color transparent] ifNotNil: [myRoot color].
	[underLyingColor isTransparent and: [(myRoot _ myRoot owner) notNil]] whileTrue: [
		underLyingColor _ myRoot color.
	].
	
	"rude hack to get the desired effect before we have an owner"

	underLyingColor isTransparent ifTrue: [underLyingColor _ Color r: 0.903 g: 1.0 b: 0.903].
	^aColor mixed: (ContrastFactor ifNil: [0.3]) with: underLyingColor

"Would like to be able to make MethodNode and outer Block be transparent.  This method does not allow that.  Consider (^ myRoot color) inside the whileTrue.  Consider setting underLyingColor to (myRoot valueOfProperty: #deselectedBorderColor ifAbsent: [myRoot color]) in second line."