isPartsDonor: aBoolean 
	"change the receiver's isPartDonor property"
	(self hasExtension not
			and: [aBoolean not])
		ifTrue: [^ self].
	self assureExtension isPartsDonor: aBoolean