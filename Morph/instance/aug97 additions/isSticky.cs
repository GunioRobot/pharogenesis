isSticky
	self flag: #deferred.  "This generic implementation of stickiness may not find favor, in which case need to back out"
	^ (self valueOfProperty: #sticky) == true