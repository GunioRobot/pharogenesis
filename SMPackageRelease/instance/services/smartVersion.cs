smartVersion
	"This method is used to ensure that we always have a
	version name for the package release even if the maintainer didn't
	bother to enter one. Is is calculated like this:
		1. If the maintainer entered a version then we use that.
		2. Otherwise we use the automatic version with an 'r' prepended.
		3. If the release is not published we enclose it in parenthesis."

	^ self isPublished ifTrue: [self eitherVersion] ifFalse: ['(', self eitherVersion, ')']