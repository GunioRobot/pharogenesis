newCard
	| aNewInstance |
	self isStackLike ifFalse: [^ self beep].
	aNewInstance _ currentDataInstance class new.
	dataInstances add: aNewInstance after: currentDataInstance.
	self installAsCurrent: aNewInstance.
	self changed