doWithTemporaryInstance: aBlock 
	| singleton |
	singleton := self current.
	
	[self current: self new.
	aBlock value] ensure: [self current: singleton]