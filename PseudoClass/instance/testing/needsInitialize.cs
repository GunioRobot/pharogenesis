needsInitialize
	^self hasMetaclass and:[
		self metaClass selectors includes: #initialize]