visible: aBoolean 
	"set the 'visible' attribute of the receiver to aBoolean"
	(self hasExtension not and:[aBoolean])
				ifTrue: [^ self].
	self visible == aBoolean
		ifTrue: [^ self].
	self assureExtension visible: aBoolean.
	self changed