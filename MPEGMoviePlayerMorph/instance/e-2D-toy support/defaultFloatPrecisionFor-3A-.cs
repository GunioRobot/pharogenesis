defaultFloatPrecisionFor: aGetSelector 
	"Answer a number indicating the default float precision to be  
	used in a numeric readout for which the receiver provides the 
	data. Individual morphs can override this. Showing fractional  
	values for readouts of getCursor was in response to an explicit 
	request from ack"
	aGetSelector == #getVolume
		ifTrue: [^ 0.01].
	aGetSelector == #getPosition 
		ifTrue: [^ 0.001].
	^ super defaultFloatPrecisionFor: aGetSelector