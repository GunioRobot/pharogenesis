invalidRect: damageRect

	self damageRecorder ifNotNil:
		[self damageRecorder recordInvalidRect: damageRect]
