description
	self selectedDependency ifNotNilDo: [:dep | ^ ('Package: ', dep package name, String cr,
		dep versionInfo summary) asText].
	self selectedRepository ifNotNilDo: [:repo | ^repo creationTemplate
		ifNotNil: [repo creationTemplate asText]
		ifNil: [repo asCreationTemplate asText addAttribute: TextColor red]].
	^ ''
