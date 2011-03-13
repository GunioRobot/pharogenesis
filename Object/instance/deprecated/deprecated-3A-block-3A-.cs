deprecated: anExplanationString block: aBlock 
	 "Warn that the sender has been deprecated.  Answer the value of aBlock on resumption.  
	 (Note that deprecated: is the preferred method.)"

	 self deprecated: anExplanationString.
	 ^ aBlock value.
