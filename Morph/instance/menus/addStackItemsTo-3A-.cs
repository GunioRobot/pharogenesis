addStackItemsTo: aMenu
	"Add stack-related items to the menu"

	| stackSubMenu |
	stackSubMenu _ MenuMorph new defaultTarget: self.
	(owner notNil and: [owner isStackBackground]) ifTrue:
		[self isShared
			ifFalse:
				[self couldHoldSeparateDataForEachInstance
					ifTrue:
						[stackSubMenu add: 'Background field, shared value' translated target: self action: #putOnBackground.
						stackSubMenu add: 'Background field, individual values' translated target: self action: #becomeSharedBackgroundField]
					ifFalse:
						[stackSubMenu add: 'put onto Background' translated target: self action: #putOnBackground]]
			ifTrue:
				[stackSubMenu add: 'remove from Background' translated target: self action: #putOnForeground.
				self couldHoldSeparateDataForEachInstance ifTrue:
					[self holdsSeparateDataForEachInstance
						ifFalse:
							[stackSubMenu add: 'start holding separate data for each instance' translated target: self action: #makeHoldSeparateDataForEachInstance]
						ifTrue:
							[stackSubMenu add: 'stop holding separate data for each instance' translated target: self action: #stopHoldingSeparateDataForEachInstance].
							stackSubMenu add: 'be default value on new card' translated target: self action: #setAsDefaultValueForNewCard.
							(self hasProperty: #thumbnailImage)
								ifTrue:
									[stackSubMenu add: 'stop using for reference thumbnail' translated target: self action: #stopUsingForReferenceThumbnail]
								ifFalse:
									[stackSubMenu add: 'start using for reference thumbnail' translated target: self action: #startUsingForReferenceThumbnail]]].
				stackSubMenu addLine].

	(self isStackBackground) ifFalse:
		[stackSubMenu add: 'be a card in an existing stack...' translated action: #insertAsStackBackground].
	stackSubMenu add: 'make an instance for my data' translated action: #abstractAModel.
	(self isStackBackground) ifFalse:
		[stackSubMenu add: 'become a stack of cards' translated action: #wrapWithAStack].
	aMenu add: 'stacks and cards...' translated subMenu: stackSubMenu
