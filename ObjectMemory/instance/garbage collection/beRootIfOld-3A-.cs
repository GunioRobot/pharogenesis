beRootIfOld: oop
	"If this object is old, mark it as a root (because a new object may be stored into it)"

	self inline: false.
	((oop < youngStart) and: [(self isIntegerObject: oop) not]) ifTrue:
		["Yes, oop is an old object"
		self noteAsRoot: oop headerLoc: oop].