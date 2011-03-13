showDesignationsOfObjects
	"Momentarily show the designations of objects on the receiver"

	| colorToUse aLabel |
	self isStackBackground ifFalse: [^ self].
	
	self submorphsDo: [:aMorph | 
		aMorph renderedMorph holdsSeparateDataForEachInstance 
			ifTrue:
				[colorToUse _ Color orange.
				aLabel _ aMorph externalName]
			ifFalse:
				[colorToUse _ aMorph isShared
					ifFalse:	[Color red]
					ifTrue:	[Color green].
				aLabel _ nil].
		Display border: (aMorph fullBoundsInWorld insetBy:  -6) width: 6 rule: Form over fillColor: colorToUse.
		aLabel ifNotNil:
			[aLabel asString displayOn: Display at: (aMorph fullBoundsInWorld bottomLeft + (0 @ 5))]].
	Sensor anyButtonPressed
		ifTrue:	[Sensor waitNoButton]
		ifFalse:	[Sensor waitButton].

	Display repaintMorphicDisplay