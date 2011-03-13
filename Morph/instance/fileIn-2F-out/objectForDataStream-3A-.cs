objectForDataStream: refStrm
	| dp |
	"I am being written out on an object file"

	self sqkPage ifNotNil: [
		(refStrm rootObject == self) | (refStrm rootObject == self sqkPage) ifFalse: [
			self url size > 0 ifTrue: [
				dp _ self sqkPage copyForSaving.	"be careful touching this object!"
				refStrm replace: self with: dp.
				^ dp]]].
	self prepareToBeSaved.		"Amen"
	^ self
