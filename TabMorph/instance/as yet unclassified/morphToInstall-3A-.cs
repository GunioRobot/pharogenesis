morphToInstall: m
	morphToInstall _ m.
	self contents: m externalName.
	self actionSelector: #tabSelected.
	self target: self