writeBaseInfo: aVersionInfo
	| string |
	string := self serializeVersionInfo: aVersionInfo.
	self addString: string at: 'base'.
