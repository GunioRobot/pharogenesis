fileOutClass: extraClass andObject: theObject 
	self binary.
	UTF8TextConverter writeBOMOn: self.
	self text.
	^ super fileOutClass: extraClass andObject: theObject