cBytesReplace: pTo from: start to: stop with: pFrom startingAt: repStart 
	"C indexed!"
	self returnTypeC: 'int'.
	self var: #pTo declareC: 'unsigned char * pTo'.
	self var: #pFrom declareC: 'unsigned char * pFrom'.
	self var: #start declareC: 'int start'.
	self var: #stop declareC: 'int stop'.
	self var: #repStart declareC: 'int repStart'.
	^ self
		cBytesCopyFrom: pFrom + repStart
		to: pTo + start
		len: stop - start + 1