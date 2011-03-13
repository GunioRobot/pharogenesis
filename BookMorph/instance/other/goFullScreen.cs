goFullScreen

	| floater |

	self isInFullScreenMode ifTrue: [^self].
	self setProperty: #fullScreenMode toValue: true.
	self position: (currentPage topLeft - self topLeft) negated.
	self adjustCurrentPageForFullScreen.
	floater _ self buildFloatingPageControls.
	self setProperty: #floatingPageControls toValue: floater.
	floater openInWorld.
