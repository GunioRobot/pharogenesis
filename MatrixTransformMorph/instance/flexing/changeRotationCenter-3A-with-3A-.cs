changeRotationCenter: evt with: rotHandle
	| pos |
	pos _ evt cursorPoint.
	rotHandle referencePosition: pos.
	self referencePosition: pos.