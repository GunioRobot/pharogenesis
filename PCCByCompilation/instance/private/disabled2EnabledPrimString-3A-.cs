disabled2EnabledPrimString: aDisabledPrimString
	"remove comment quotes and comment after first comment quote"
	| enabledPrimString |
	enabledPrimString := aDisabledPrimString copyFrom: self comment size + 2 to: aDisabledPrimString size - 1.
	^ enabledPrimString