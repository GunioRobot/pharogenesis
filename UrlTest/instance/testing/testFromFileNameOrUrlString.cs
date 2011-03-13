testFromFileNameOrUrlString

	url _ Url absoluteFromFileNameOrUrlString: 'asdf'.
	self assert: url schemeName = 'file'.
	self assert: url fragment isNil.
	self assert: url class = FileUrl.

	url _ Url absoluteFromFileNameOrUrlString: 'http://209.143.91.36/super/SuperSwikiProj/AAEmptyTest.001.pr'.
	self assert: url schemeName = 'http'.
	self assert: url fragment isNil.
	self assert: url class = HttpUrl.