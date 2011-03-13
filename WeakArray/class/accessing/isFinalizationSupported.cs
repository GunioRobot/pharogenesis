isFinalizationSupported
	"Check if this VM supports the finalization mechanism"
	| tempObject |
	IsFinalizationSupported ifNotNil:[^IsFinalizationSupported].
	tempObject := WeakArray new: 1.
	"Check if the class format 4 is correctly understood by the VM.
	If the weak class support is not installed then the VM will report
	any weak class as containing 32bit words - not pointers"
	(tempObject at: 1) = nil 
		ifFalse:[^IsFinalizationSupported :=false].
	"Check if objects are correctly freed"
	self pvtCreateTemporaryObjectIn: tempObject.
	Smalltalk garbageCollect.
	^IsFinalizationSupported := (tempObject at: 1) == nil