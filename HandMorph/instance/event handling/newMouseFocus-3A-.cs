newMouseFocus: aMorphOrNil

	| itsPasteUp toView |
	((mouseDownMorph isKindOf: MenuItemMorph)
		and: [(aMorphOrNil isKindOf: MenuItemMorph) not])
		ifTrue: [(mouseDownMorph owner isKindOf: MenuMorph)
				ifTrue: ["Crock: If a menu is proffered with the mouse up
						and the user clicks down outside it (as is normal in MVC),
						then the menu goes away and nothing else happens."
						mouseDownMorph owner deleteIfPopUp.
						^ nil]].
	aMorphOrNil ifNotNil: 
		[((itsPasteUp  _ aMorphOrNil pasteUpMorph) notNil and:
			[itsPasteUp automaticViewing]) ifTrue:
				[toView _ itsPasteUp
					submorphThat:
						[:aMorph | aMorphOrNil hasInOwnerChain: aMorph]
					ifNone:
						[nil].
				(toView notNil and: [toView isCandidateForAutomaticViewing]) ifTrue:
					[toView openViewerForArgument]]].

	mouseDownMorph _ aMorphOrNil.
	self updateMouseDownTransform.
