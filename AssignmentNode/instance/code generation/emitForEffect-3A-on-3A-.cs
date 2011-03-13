emitForEffect: stack on: aStream

	variable emitLoad: stack on: aStream.
	value emitForValue: stack on: aStream.
	pc := aStream position + 1. "debug pc is first byte of the store".
	variable emitStorePop: stack on: aStream