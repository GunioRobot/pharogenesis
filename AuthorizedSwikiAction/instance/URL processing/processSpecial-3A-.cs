processSpecial: request
	"Let SwikiAction process this with no authorization check."

	^(super process: request).