initialize

	super initialize.
	format _ #default.  "formats: #string, #default"
	target _ getSelector _ putSelector _  nil.
	floatPrecision _ 1.
	growable _ true.
	stepTime _ 50.
	autoAcceptOnFocusLoss _ true.
	minimumWidth _ 8.
	maximumWidth _ 300.
