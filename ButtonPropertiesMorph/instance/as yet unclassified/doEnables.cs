doEnables

	| itsName |

	self allMorphsDo: [ :each |
		itsName _ each knownName.
		itsName == #pickerForMouseDownColor ifTrue: [
			self enable: each when: self targetWantsRollover
		].
		itsName == #pickerForMouseOverColor ifTrue: [
			self enable: each when: self targetWantsRollover
		].
		itsName == #paneForRepeatingInterval ifTrue: [
			self enable: each when: self targetRepeatingWhileDown
		].
	].
