restoreFrom: filename
	|f|
	f _ ReferenceStream fileNamed: filename.
	self map: f next.
	self map action: self.
	f close.