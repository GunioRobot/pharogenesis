showDesignationsOfObjects
	"Momentarily show the designations of objects on the receiver"

	| colorToUse aLabel |
	self isStackBackground ifFalse: [^self].
	self submorphsDo: 
			[:aMorph | 
			aLabel :=aMorph renderedMorph holdsSeparateDataForEachInstance 
				ifTrue: 
					[colorToUse := Color orange.
					 aMorph externalName]
				ifFalse: 
					[colorToUse := aMorph isShared ifFalse: [Color red] ifTrue: [Color green].
					 nil].
			Display 
				border: (aMorph fullBoundsInWorld insetBy: -6)
				width: 6
				rule: Form over
				fillColor: colorToUse.
			aLabel ifNotNil: 
					[aLabel asString 
						displayOn: Display
						at: aMorph fullBoundsInWorld bottomLeft + (0 @ 5)
						textColor: Color blue]].
	Sensor anyButtonPressed 
		ifTrue: [Sensor waitNoButton]
		ifFalse: [Sensor waitButton].
	World fullRepaintNeeded