updateDisplay
	"The working version is redefined by copying the bits displayed in the 
	receiver's display area."

	displayedForm fromDisplay: self displayBox.
	displayedForm changed: self