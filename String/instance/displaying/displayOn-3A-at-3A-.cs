displayOn: aDisplayMedium at: aPoint 
	"Show a representation of the receiver as a DisplayText at location
	aPoint on aDisplayMedium."

	(self asDisplayText foregroundColor: Color black backgroundColor: Color white)
		displayOn: aDisplayMedium at: aPoint