addCustomMenuItems: aCustomMenu hand: aHandMorph
	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	aCustomMenu addList: 
		#(('border color...' changeBorderColor:)
		('border width...' changeBorderWidth:)).
	self couldHaveRoundedCorners ifTrue:
		[aCustomMenu addUpdating: #roundedCornersString target: self action: #toggleCornerRounding].

	self doesBevels ifTrue:
		[borderColor == #raised ifFalse: [aCustomMenu add: 'raised bevel' action: #borderRaised].
		borderColor == #inset ifFalse: [aCustomMenu add: 'inset bevel' action: #borderInset]]
