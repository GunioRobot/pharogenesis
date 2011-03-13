toggleIsPartsBin
	isPartsBin _ self isPartsBin not.
	isPartsBin
		ifTrue:
			[submorphs do:
				[:m | m setProperty: #partsDonor toValue: true.
					m suspendEventHandler]]
		ifFalse:
			[submorphs do:
				[:m | m removeProperty: #partsDonor.
					m restoreSuspendedEventHandler]]