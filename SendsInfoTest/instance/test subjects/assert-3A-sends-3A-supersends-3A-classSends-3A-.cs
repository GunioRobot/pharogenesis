assert: aSelector sends: sendsCollection supersends: superCollection classSends: classCollection
	| theMethod info |
	theMethod := self class >> aSelector.
	info := (SendInfo on: theMethod) collectSends.
	self assert: #self sendsIn: info for: aSelector are: sendsCollection.
	self assert: #super sendsIn: info for: aSelector are: superCollection.
	self assert: #class sendsIn: info for: aSelector are: classCollection.
