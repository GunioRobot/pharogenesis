visible: aBoolean 
	"set the 'visible' attribute of the receiver to aBoolean"
	self hasExtension
		ifFalse: [aBoolean
				ifTrue: [^ self]].
	self assureExtension visible: aBoolean