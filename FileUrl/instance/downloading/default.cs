default
	"Use the default local Squeak file directory"
	| local |
	local _ FileUrl new path: (FileDirectory default pathParts), #('')
		isAbsolute: true.
	self privateInitializeFromText: self pathString relativeTo: local.
		"sets absolute also"