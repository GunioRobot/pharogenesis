setDefaultDirectoryFrom: imageName
	self activeDirectoryClass convertName: imageName
		to: [:directory :fileName | DefaultDirectory _ directory]