transfer: count
	fromIndex: firstFrom ofObject: fromOop
	toIndex: firstTo ofObject: toOop
	"Assume: beRootIfOld: will be called on toOop."

	| fromIndex toIndex lastFrom |
	self inline: true.
	fromIndex _ fromOop + (firstFrom * 4).
	toIndex _ toOop + (firstTo * 4).
	lastFrom _ fromIndex + (count * 4).
	[fromIndex < lastFrom] whileTrue: [
		fromIndex _ fromIndex + 4.
		toIndex _ toIndex + 4.
		self longAt: toIndex put: (self longAt: fromIndex).
	].