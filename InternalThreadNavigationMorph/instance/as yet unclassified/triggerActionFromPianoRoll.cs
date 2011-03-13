triggerActionFromPianoRoll

	| proj |

	WorldState addDeferredUIMessage: [
		self currentIndex >= listOfPages size ifTrue: [^1 beep].
		currentIndex _ self currentIndex + 1.
		proj _ Project named: ((listOfPages at: currentIndex) at: 1).
		proj world setProperty: #letTheMusicPlay toValue: true.
		proj enter.
	]