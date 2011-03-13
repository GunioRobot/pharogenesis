addCustomMenuItems: aMenu hand: aHandMorph
	super addCustomMenuItems: aMenu hand: aHandMorph.
	self isWorldMorph ifFalse:
		[aMenu addList: 
			#(('border color...' changeBorderColor:)
			('border width...' changeBorderWidth:)).
		self couldHaveRoundedCorners ifTrue:
			[aMenu addUpdating: #roundedCornersString target: self action: #toggleCornerRounding].

		self doesBevels ifTrue:
			[borderColor == #raised ifFalse: [aMenu add: 'raised bevel' action: #borderRaised].
			borderColor == #inset ifFalse: [aMenu add: 'inset bevel' action: #borderInset]]]
