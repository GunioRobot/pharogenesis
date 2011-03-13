displayOn: aDisplayMedium lines: lineInterval

	| saveDestinationForm |
	saveDestinationForm _ destinationForm.
	destinationForm _ aDisplayMedium.
	self displayLines: lineInterval.
	destinationForm _ saveDestinationForm