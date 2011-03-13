positionVertically

	| wb stickToTop |

	owner == self world ifFalse: [^self].
	wb _ self worldBounds.
	stickToTop _ self valueOfProperty: #stickToTop.
	stickToTop ifNil: [
		stickToTop _ (self top - wb top) abs < (self bottom - wb bottom) abs.
		self setProperty: #stickToTop toValue: stickToTop.
	].
	mouseInside == true ifTrue: [
		stickToTop ifTrue: [
			self top: wb top
		] ifFalse: [
			self bottom: wb bottom
		].
	] ifFalse: [
		stickToTop ifTrue: [
			self bottom: wb top + self amountToShowWhenSmall
		] ifFalse: [
			self top: wb bottom - self amountToShowWhenSmall
		].
	].

