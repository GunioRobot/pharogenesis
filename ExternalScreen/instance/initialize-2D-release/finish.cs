finish
	"Flush the receiver"
	self primFinish: bits.
	"Now is the time to do some cleanup"
	allocatedForms unlock.
	allocatedForms finalizeValues.