objectForDataStream: refStrm
	"I am being written out on an object file"

	self sqkPage ifNotNil: [
		(refStrm rootObject == self) | (refStrm rootObject == self sqkPage) ifFalse: [
			self url size > 0 ifTrue: [
				^ self sqkPage copyForSaving]]].	"be careful touching this object!"
	self prepareToBeSaved.		"Amen"
	^ self
