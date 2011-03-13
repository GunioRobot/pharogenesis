displayOn: aDisplayMedium lines: lineInterval

	| saveDestinationForm |
	saveDestinationForm := destinationForm.
	destinationForm := aDisplayMedium.
	self displayLines: lineInterval.
	destinationForm := saveDestinationForm