doEnables

	| itsName fs |

	fs _ myTarget fillStyle.
	self allMorphsDo: [ :each |
		itsName _ each knownName.
		itsName == #pickerForColor ifTrue: [
			self enable: each when: fs isSolidFill | fs isGradientFill
		].
		itsName == #pickerForBorderColor ifTrue: [
			self enable: each when: (myTarget respondsTo: #borderColor:)
		].
		itsName == #pickerForShadowColor ifTrue: [
			self enable: each when: myTarget hasDropShadow
		].
		itsName == #pickerFor2ndGradientColor ifTrue: [
			self enable: each when: fs isGradientFill
		].
	].
