terminateAndInitializeAround: aBlock
	"1/12/96 sw"
	self controlTerminate.
	aBlock value.
	self controlInitialize