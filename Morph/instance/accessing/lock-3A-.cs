lock: aBoolean 
	"change the receiver's lock property"
	(self hasExtension not
			and: [aBoolean not])
		ifTrue: [^ self].
	self assureExtension locked: aBoolean