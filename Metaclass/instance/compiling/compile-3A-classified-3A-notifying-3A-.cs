compile: code classified: heading notifying: requestor 
	"Make sure there is an organization before compiling."

	organization _ self organization.
	^super
		compile: code
		classified: heading
		notifying: requestor