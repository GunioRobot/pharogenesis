transformDirection: aVector3
	| zero one |
	zero _ B3DVector3 new.
	one _ zero + aVector3.
	zero _ self transformPosition: zero.
	one _ self transformPosition: one.
	^one - zero