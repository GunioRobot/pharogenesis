exitFullScreen

	| floater |

	self isInFullScreenMode ifFalse: [^self].
	self setProperty: #fullScreenMode toValue: false.
	floater _ self valueOfProperty: #floatingPageControls ifAbsent: [nil].
	floater ifNotNil: [
		floater delete.
		self removeProperty: #floatingPageControls.
	].
	self position: 0@0.
	self adjustCurrentPageForFullScreen.
