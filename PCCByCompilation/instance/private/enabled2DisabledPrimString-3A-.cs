enabled2DisabledPrimString: anEnabledPrimString 
	| disabledPrimString |
	disabledPrimString := '"' , self comment , anEnabledPrimString , '"'.
	^ disabledPrimString