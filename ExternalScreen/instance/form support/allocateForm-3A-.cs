allocateForm: extentPoint
	"Allocate a new form which is similar to the receiver and can be used for accelerated blts"
	| formHandle displayForm |
	formHandle _ self primAllocateForm: self depth width: extentPoint x height: extentPoint y.
	formHandle = nil ifTrue:[^super allocateForm: extentPoint].
	displayForm _ (ExternalForm extent: extentPoint depth: self depth bits: nil) 
		setExternalHandle: formHandle on: self.
	allocatedForms at: displayForm put: displayForm executor.
	^displayForm