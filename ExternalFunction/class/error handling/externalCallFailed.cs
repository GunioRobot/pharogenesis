externalCallFailed
	"Raise an error after a failed call to an external function"
	| errCode |
	errCode _ self getLastError. "this allows us to look at the actual error code"
	^self error: (self errorMessageFor: errCode).