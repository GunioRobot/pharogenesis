unhibernate
	bits isInteger ifTrue:[^false]. "handled transparently"
	bits ifNotNil:[
		bits size = 0 ifTrue:[self prepareForUpload. ^true]].
	^super unhibernate