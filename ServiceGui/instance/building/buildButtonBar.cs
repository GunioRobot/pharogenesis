buildButtonBar
	bar := self buttonBarFor: service.
	self class registerBar: bar for: service.
	^ bar